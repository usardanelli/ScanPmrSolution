

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ScanPmrWinForm.ViewModel;
using ScanPmrWinForm.Views;
using TwainDotNet;
using TwainDotNet.WinFroms;
using ZXing;
using System.Security.Cryptography.X509Certificates;
using ScanPmrWinForm.ServiceReferencePmr;

namespace ScanPmrWinForm
{
    public partial class MainForm : Form
    {
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        private PmrNumberForm pmrNumberForm = null;
        private List<PmrElementClass> pmrElements = null;
        Twain _twain;
        ScanSettings _settings;
        List<Image> images = null;

        private string _codeOp = string.Empty;

        private readonly string _tempPath = $"{Path.GetTempPath()}\\SCANSIONI_PMR";

        private void ShowDataGrid()
        {
            dataGridViewPmr.Show();

            VisualizzaImmagini();

            panelBtnSaveAndCanc.Visible = true;
        }

        private void TaskVisualizzaScansione(int imgCount)
        {
            int resto = imgCount % 2;

            if (resto == 0)
            {
                if (pmrNumberForm.PmrNumber != imgCount / 2)
                {
                    DialogResult result = MessageBox.Show($"Sei sicuro di voler continuare? Il numero di plichi da scansire inserito n = {pmrNumberForm.PmrNumber} è diverso dal numero di plichi scansiti n = {images.Count / 2}", "Sicuro di voler continuare?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    if (result == DialogResult.Yes)
                        ShowDataGrid();
                }
                else
                    ShowDataGrid();
            }
            else
            {
                DialogResult result = MessageBox.Show($"Sei sicuro di voler continuare? Il numero di immagini scansite n = {images.Count} non è un numero pari e non può formare correttamente i plichi ", "Sicuro di voler continuare?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.Yes)
                    ShowDataGrid();

            }
        }

        public MainForm(UserViewModel viewModel)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            _codeOp = viewModel.Username;
            lblUsername.Text = $"Username: {viewModel.Username}";
            lblDomain.Text = $"Domain: {viewModel.Domain}";
            HideInizialize();
            images = new List<Image>();
            _twain = new Twain(new WinFormsWindowMessageHook(this));
            _twain.TransferImage += delegate (Object sender, TransferImageEventArgs args)
            {
                if (args.Image != null)
                {
                    images.Add(args.Image);
                    Image image = args.Image;
                    string barCode = DecodeImg(new Bitmap(image));
                    string filename = GetFileName(images.Count, barCode);

                    if(images.Count % 2 != 0) image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    image.Save($"{_tempPath}\\{filename}.jpg"
                                     , ImageFormat.Jpeg);

                    image.Dispose();
                }
            };
            _twain.ScanningComplete += delegate
            {
                Enabled = true;

                TaskVisualizzaScansione(images.Count());

            };

        }
        private void HideInizialize()
        {
          
            dataGridViewPmr.Hide();
            splitContainerMonitor.Hide();
            panel2.Hide();
        }
        private string GetFileName(int count, string barcode)
        {
            if (count < 10)
            {
                return string.IsNullOrEmpty(barcode) ? $"0{count}_ImmagineSenzaCodice" : $"0{ count}_{barcode}";
            }

            return string.IsNullOrEmpty(barcode) ? $"{count}_ImmagineSenzaCodice" : $"{ count}_{barcode}";

        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContainer.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);

        }
        private void ScanMethod()
        {
            if (Directory.Exists(_tempPath))
            {
                Directory.Delete(_tempPath, true);
            }

            Directory.CreateDirectory(_tempPath);

            pmrNumberForm = new PmrNumberForm();
            pmrNumberForm.ShowDialog();

            if (pmrNumberForm.DialogResult == DialogResult.OK)
            {
                Enabled = false;

                _settings = new ScanSettings();
                _settings.UseDocumentFeeder = false;
                _settings.ShowTwainUI = true;
                _settings.ShowProgressIndicatorUI = true;
                _settings.UseDuplex = false;
                _settings.Resolution = ResolutionSettings.ColourPhotocopier;
                _settings.Area = null;
                _settings.ShouldTransferAllPages = true;

                _settings.Rotation = new RotationSettings()
                {
                    AutomaticRotate = false,
                    AutomaticBorderDetection = false
                };

                try
                {
                    _twain.StartScanning(_settings);
                }
                catch (TwainException ex)
                {
                    MessageBox.Show(ex.Message, "Eccezione di scansione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("La scansione è stata annullata", "Scansione annullata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void scan_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelBtnSaveAndCanc.Visible)
                {
                    DialogResult result = MessageBox.Show("Sei sicuro di voler avviare una nuova scansione? Perderai le eventuali scansioni non salvate", "Sicuro di voler continuare?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    if (result == DialogResult.Yes)
                    {
                        ScanMethod();
                    }

                }
                else
                {
                    ScanMethod();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int lx, ly;
        int sw, sh;
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestoreScreen_Click(object sender, EventArgs e)
        {
            btnFullScreen.Visible = true;
            btnRestoreScreen.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);

        }


        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnFullScreen.Visible = false;
            btnRestoreScreen.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panelMenu.Visible)
                panelMenu.Visible = false;
            else
                panelMenu.Visible = true;

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();

        }

        private void btnSelectScanner_Click(object sender, EventArgs e)
        {
            try
            {
                _twain.SelectSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenDetailForm(string imgFronte, string imgRetro)
        {
            DetailPmrForm form = new DetailPmrForm(imgFronte, imgRetro);
            OpenForm(form);
        }


        private static readonly List<BarcodeFormat> Fmts = new List<BarcodeFormat> { BarcodeFormat.All_1D };



        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                imageListPmr.Images.Clear();

                images.Clear();
                dataGridViewPmr.Hide();
                splitContainerMain.Hide();
                lblPlichiAnomali.Text = "0";
                lblPlichiValidi.Text = "0";
                lblTotale.Text = "0";

                if (Directory.Exists(_tempPath))
                {
                    Directory.Delete(_tempPath, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainerDetailForm.Hide();
                splitContainerMain.Show();

                DetailPmrForm form;
                form = panelContainer.Controls.OfType<DetailPmrForm>().FirstOrDefault();
                form.DisposeImages();
                form.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string DecodeImg(Bitmap img)

        {
            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options =
            {
                PossibleFormats = Fmts,
                TryHarder = true,
                ReturnCodabarStartEnd = true,
                PureBarcode = false
            }
            };
            Result result = reader.Decode(img);

            if (result != null)
            {
                return result.Text;
            }

            return string.Empty;
        }

        private void progressBarMarquee()
        {
            panel2.Show();
            // Set Minimum to 1 to represent the first file being copied.
            pBimages.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            pBimages.Maximum = 100;
            // Set the initial value of the ProgressBar.
            pBimages.Value = 50;
            // Set the Step property to a value of 1 to represent each file being copied.
            pBimages.Step = 50;

        }

        private void progressBarInizialize(int maximum)
        {
            panel2.Show();
          
            // Set Minimum to 1 to represent the first file being copied.
            pBimages.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            pBimages.Maximum = maximum;
            // Set the initial value of the ProgressBar.
            pBimages.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            pBimages.Step = 1;

           
        }
     
        private void VisualizzaImmagini()
        {
            try
            {
                string[] paths = Directory.GetFiles(@"C:\Users\umber\Desktop\Test");
                Bitmap bf, br = null;
                pmrElements = new List<PmrElementClass>();
                PmrElementClass pmrElement = null;
                if (paths.Length == 1)
                {
                    bf = new Bitmap(paths[0]);
                    imageListPmr.Images.Add(bf);
                    pmrElement = new PmrElementClass(1, imageListPmr.Images[0], null, DecodeImg(bf), paths[0], string.Empty);
                    pmrElements.Add(pmrElement);
                    bf.Dispose();
                    dataGridViewPmr.DataSource = pmrElements;

                    UpdateDataGrid();
                }
                else
                {
                    progressBarInizialize(paths.Length / 2);
                    int j = 1;
                    for (int i = 0; i < paths.Length - 1; i += 2)
                    {
                        bf = new Bitmap(paths[i +1]);
                        br = new Bitmap(paths[i]);

                        imageListPmr.Images.Add(bf);
                        imageListPmr.Images.Add(br);
                        string code = DecodeImg(bf);
                        if (!string.IsNullOrEmpty(code)) code = code.Remove(code.Length - 1);
                        pmrElement = new PmrElementClass(j, imageListPmr.Images[i], imageListPmr.Images[i + 1], code, paths[i +1], paths[i]);
                        pmrElements.Add(pmrElement);
                        bf.Dispose();
                        br.Dispose();
                        j++;
                        pBimages.PerformStep();
                    }
                    panel2.Hide();

                    splitContainerMain.Show();

                    dataGridViewPmr.DataSource = pmrElements;

                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateDataGrid()
        {
            int countSucces = 0;
            int countError = 0;
           
            foreach (DataGridViewRow row in dataGridViewPmr.Rows)
            {
                PmrElementClass pmr = (PmrElementClass)row.DataBoundItem;
                if (pmr.ErrorScan)
                {
                    if (pmrElements.Where(p => p.Codice == pmr.Codice && p.Codice.Length > 0).ToList().Count > 1)
                        row.Cells[0].Style.BackColor = Color.Violet;
                    else
                        row.Cells[0].Style.BackColor = Color.OrangeRed;
                    
                    row.Cells[4].ToolTipText = "Il PMR selezionato è  già scartato";
                    countError++;
                }
                else
                {
                    if (pmrElements.Where(p => p.Codice == pmr.Codice).ToList().Count > 1)
                    {
                        row.Cells[0].Style.BackColor = Color.Violet;
                        row.Cells[4].ToolTipText = "Il PMR selezionato è  già scartato";
                        pmr.ErrorScan = true;
                        countError++;
                    }
                    else
                    {
                        countSucces++;
                        row.Cells[0].Style.BackColor = Color.LightGreen;
                        row.Cells[4].ToolTipText = "Scarta il PMR selezionato";
                    }                  

                }
              
                
            }
            List<string> codici = new List<string>();
      
         

            lblTotale.Text = dataGridViewPmr.Rows.Count.ToString();
            lblPlichiValidi.Text = countSucces.ToString();
            lblPlichiAnomali.Text = countError.ToString();
            lblPlichiAnomali.Text = countError.ToString();
        }

        private bool customXertificateValidation(object sender, X509Certificate cert,
         X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            var certificate = (X509Certificate2)cert;
            return true;
        }
        private string GetBarCodes()
        {
            string barCodes = string.Empty;

            foreach (DataGridViewRow row in dataGridViewPmr.Rows)
            {

                PmrElementClass pmr = (PmrElementClass)row.DataBoundItem;
                if (!pmr.ErrorScan)
                {
                    if (row.Index == dataGridViewPmr.Rows.Count - 1)
                        barCodes += pmr.Codice;
                    else
                        barCodes += string.Concat(pmr.Codice, ",");
                }
            }
            return barCodes;
        }

        private void btnSavePmr_Click(object sender, EventArgs e)
        {
            try
            {
                string _barCodes = GetBarCodes();
                List<PmrElementClass> pmrToInsert = null;
                if (!string.IsNullOrWhiteSpace(_barCodes))
                {
                    progressBarMarquee();

                    using (var proxy = new ScanPmrServiceClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback += customXertificateValidation;

                        string _returnValidation = proxy.ValidationBarCodes(_barCodes);

                        string[] _validationErrorCodes = _returnValidation.Split('-');

                        if (_validationErrorCodes.Length > 0)
                        {
                            for (int i = 0; i < _validationErrorCodes.Length - 1; i++)
                            {
                                pmrElements.Where(x => x.Codice == _validationErrorCodes[i]).SingleOrDefault().ErrorValidation = true;
                            }
                        }
                        pBimages.PerformStep();
                        panel2.Hide();
                        pmrToInsert = pmrElements.Where(x => x.InsertSuccess == true).ToList();
                        if (pmrToInsert.Count > 0)
                        {
                            progressBarInizialize(pmrToInsert.Count);
                            foreach (var pmr in pmrToInsert)
                            {
                                proxy.InsertPmr(CreateArscan(pmr));
                                pBimages.PerformStep();
                            }
                            pBimages.Hide();
                        }

                    }
                    panel2.Hide();
                }
                OpenMonitor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panel2.Hide();
            }

        }
        private void OpenMonitor()
        {
            splitContainerMain.Hide();
            lblInseriti.Text = pmrElements.Where(x => x.InsertSuccess == true).ToList().Count.ToString();
            lblScartiScan.Text = pmrElements.Where(x => x.ErrorScan == true).ToList().Count.ToString();
            lblScartiVal.Text = pmrElements.Where(x => x.ErrorValidation == true).ToList().Count.ToString();
            lblScartiIns.Text = pmrElements.Where(x => x.ErrorInsert == true).ToList().Count.ToString();
            MonitorPmrForm form = new MonitorPmrForm(pmrElements);
            splitContainerMonitor.Show();
            scan.Enabled = false;
            OpenForm(form);
        }
        private void OpenForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            panelContainer.Tag = form;
            form.Show();
            form.BringToFront();
        }

        private ARSCAN CreateArscan(PmrElementClass pmr)
        {
            ARSCAN _arscan = new ARSCAN()
            {
                IMMAGINE_FRONTE = GetByteFromPath(pmr.NomeFileFronte),
                IMMAGINE_RETRO = GetByteFromPath(pmr.NomeFileRetro),
                CODE_BAR = pmr.Codice,
                CODE_OPE_SCAN = _codeOp
            };
            return _arscan;
        }
        private byte[] GetByteFromPath(string fileName)
        {
            FileStream stream = new FileStream(
               fileName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            return photo;
        }

        private void dataGridViewPmr_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           MessageBox.Show(e.Exception.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                splitContainerMonitor.Hide();

                MonitorPmrForm form;
                form = panelContainer.Controls.OfType<MonitorPmrForm>().FirstOrDefault();
                form.Close();

                imageListPmr.Images.Clear();

                images.Clear();
                dataGridViewPmr.Hide();
                splitContainerMain.Hide();
                lblPlichiAnomali.Text = "0";
                lblPlichiValidi.Text = "0";
                lblTotale.Text = "0";
                lblInseriti.Text = "0";
                lblScartiIns.Text = "0";
                lblScartiScan.Text = "0";
                lblScartiVal.Text = "0";
                scan.Enabled = true;
                if (Directory.Exists(_tempPath))
                {
                    Directory.Delete(_tempPath, true);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void  dataGridViewPmr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var currentRow = dataGridViewPmr.Rows[e.RowIndex];
                    var cell = currentRow.Cells[e.ColumnIndex];
                    PmrElementClass pmr = (PmrElementClass)currentRow.DataBoundItem;
                    if (cell.ColumnIndex == 4)
                    {
                        pmr.ErrorScan = true;
                        dataGridViewPmr.DataSource = pmrElements;
                        UpdateDataGrid();
                    }
                    else
                    {
                        OpenDetailForm(pmr.NomeFileFronte, pmr.NomeFileRetro);
                        txtBoxOldCode.Text = pmr.Codice;
                        txtIndexRow.Text = e.RowIndex.ToString();
                        splitContainerDetailForm.Show();
                        splitContainerMain.Hide();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveCodeBar_Click(object sender, EventArgs e)
        {
            try
            {
                string strNewCode = txtNewCode.Text;
                if (string.IsNullOrWhiteSpace(strNewCode) || strNewCode.Length != 11)
                {
                    MessageBox.Show("Inserire un codice valido di 11 cifre per poter salvare", "Codice non consentito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    short index;
                    short.TryParse(txtIndexRow.Text, out index);
                    pmrElements[index].Codice = txtNewCode.Text;
                    pmrElements[index].ErrorScan = false;
                    txtBoxOldCode.Text = txtNewCode.Text;
                    txtNewCode.Text = string.Empty;
                    dataGridViewPmr.DataSource = pmrElements;
                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eccezione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}