namespace ScanPmrWinForm.Views
{
    partial class MonitorPmrForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabMonitorControl = new System.Windows.Forms.TabControl();
            this.tabScartiScansione = new System.Windows.Forms.TabPage();
            this.dataGridViewScarti = new System.Windows.Forms.DataGridView();
            this.ErrorScan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ErrorValidation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ErrorInsert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabInserimento = new System.Windows.Forms.TabPage();
            this.dataGridViewInserimento = new System.Windows.Forms.DataGridView();
            this.indiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fronteDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.retroDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.codiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmrElementClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMonitorControl.SuspendLayout();
            this.tabScartiScansione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScarti)).BeginInit();
            this.tabInserimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInserimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmrElementClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMonitorControl
            // 
            this.tabMonitorControl.Controls.Add(this.tabScartiScansione);
            this.tabMonitorControl.Controls.Add(this.tabInserimento);
            this.tabMonitorControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabMonitorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMonitorControl.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.tabMonitorControl.Location = new System.Drawing.Point(0, 0);
            this.tabMonitorControl.Name = "tabMonitorControl";
            this.tabMonitorControl.SelectedIndex = 0;
            this.tabMonitorControl.Size = new System.Drawing.Size(960, 500);
            this.tabMonitorControl.TabIndex = 0;
            // 
            // tabScartiScansione
            // 
            this.tabScartiScansione.AutoScroll = true;
            this.tabScartiScansione.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.tabScartiScansione.Controls.Add(this.dataGridViewScarti);
            this.tabScartiScansione.Location = new System.Drawing.Point(4, 34);
            this.tabScartiScansione.Name = "tabScartiScansione";
            this.tabScartiScansione.Padding = new System.Windows.Forms.Padding(3);
            this.tabScartiScansione.Size = new System.Drawing.Size(952, 462);
            this.tabScartiScansione.TabIndex = 0;
            this.tabScartiScansione.Text = "Scarti";
            this.tabScartiScansione.UseVisualStyleBackColor = true;
            // 
            // dataGridViewScarti
            // 
            this.dataGridViewScarti.AllowUserToAddRows = false;
            this.dataGridViewScarti.AllowUserToResizeColumns = false;
            this.dataGridViewScarti.AutoGenerateColumns = false;
            this.dataGridViewScarti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScarti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewScarti.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewScarti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewScarti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewScarti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScarti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indiceDataGridViewTextBoxColumn,
            this.fronteDataGridViewImageColumn,
            this.retroDataGridViewImageColumn,
            this.codiceDataGridViewTextBoxColumn,
            this.ErrorScan,
            this.ErrorValidation,
            this.ErrorInsert});
            this.dataGridViewScarti.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridViewScarti.DataSource = this.pmrElementClassBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewScarti.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewScarti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScarti.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewScarti.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewScarti.Name = "dataGridViewScarti";
            this.dataGridViewScarti.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewScarti.RowHeadersVisible = false;
            this.dataGridViewScarti.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightSalmon;
            this.dataGridViewScarti.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.dataGridViewScarti.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewScarti.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSalmon;
            this.dataGridViewScarti.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewScarti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewScarti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewScarti.Size = new System.Drawing.Size(946, 456);
            this.dataGridViewScarti.StandardTab = true;
            this.dataGridViewScarti.TabIndex = 0;
            // 
            // ErrorScan
            // 
            this.ErrorScan.DataPropertyName = "ErrorScan";
            this.ErrorScan.FillWeight = 85.13231F;
            this.ErrorScan.HeaderText = "Scarto Scansione";
            this.ErrorScan.Name = "ErrorScan";
            // 
            // ErrorValidation
            // 
            this.ErrorValidation.DataPropertyName = "ErrorValidation";
            this.ErrorValidation.FillWeight = 71.06599F;
            this.ErrorValidation.HeaderText = "Scarto Validazione";
            this.ErrorValidation.Name = "ErrorValidation";
            // 
            // ErrorInsert
            // 
            this.ErrorInsert.DataPropertyName = "ErrorInsert";
            this.ErrorInsert.FillWeight = 73.77711F;
            this.ErrorInsert.HeaderText = "Scarto Inserimento";
            this.ErrorInsert.Name = "ErrorInsert";
            // 
            // tabInserimento
            // 
            this.tabInserimento.AutoScroll = true;
            this.tabInserimento.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.tabInserimento.Controls.Add(this.dataGridViewInserimento);
            this.tabInserimento.Location = new System.Drawing.Point(4, 34);
            this.tabInserimento.Name = "tabInserimento";
            this.tabInserimento.Padding = new System.Windows.Forms.Padding(3);
            this.tabInserimento.Size = new System.Drawing.Size(952, 462);
            this.tabInserimento.TabIndex = 2;
            this.tabInserimento.Text = "Inseriti";
            this.tabInserimento.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInserimento
            // 
            this.dataGridViewInserimento.AllowUserToAddRows = false;
            this.dataGridViewInserimento.AllowUserToResizeColumns = false;
            this.dataGridViewInserimento.AutoGenerateColumns = false;
            this.dataGridViewInserimento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInserimento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInserimento.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewInserimento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInserimento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewInserimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInserimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn1,
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewInserimento.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridViewInserimento.DataSource = this.pmrElementClassBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInserimento.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewInserimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInserimento.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewInserimento.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInserimento.Name = "dataGridViewInserimento";
            this.dataGridViewInserimento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewInserimento.RowHeadersVisible = false;
            this.dataGridViewInserimento.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            this.dataGridViewInserimento.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.dataGridViewInserimento.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewInserimento.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGreen;
            this.dataGridViewInserimento.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewInserimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewInserimento.Size = new System.Drawing.Size(946, 456);
            this.dataGridViewInserimento.TabIndex = 1;
            // 
            // indiceDataGridViewTextBoxColumn
            // 
            this.indiceDataGridViewTextBoxColumn.DataPropertyName = "Indice";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OrangeRed;
            this.indiceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.indiceDataGridViewTextBoxColumn.FillWeight = 71.94846F;
            this.indiceDataGridViewTextBoxColumn.HeaderText = "Indice";
            this.indiceDataGridViewTextBoxColumn.Name = "indiceDataGridViewTextBoxColumn";
            // 
            // fronteDataGridViewImageColumn
            // 
            this.fronteDataGridViewImageColumn.DataPropertyName = "Fronte";
            this.fronteDataGridViewImageColumn.FillWeight = 132.692F;
            this.fronteDataGridViewImageColumn.HeaderText = "Fronte";
            this.fronteDataGridViewImageColumn.Name = "fronteDataGridViewImageColumn";
            // 
            // retroDataGridViewImageColumn
            // 
            this.retroDataGridViewImageColumn.DataPropertyName = "Retro";
            this.retroDataGridViewImageColumn.FillWeight = 132.692F;
            this.retroDataGridViewImageColumn.HeaderText = "Retro";
            this.retroDataGridViewImageColumn.Name = "retroDataGridViewImageColumn";
            // 
            // codiceDataGridViewTextBoxColumn
            // 
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.FillWeight = 132.692F;
            this.codiceDataGridViewTextBoxColumn.HeaderText = "Codice";
            this.codiceDataGridViewTextBoxColumn.Name = "codiceDataGridViewTextBoxColumn";
            // 
            // pmrElementClassBindingSource
            // 
            this.pmrElementClassBindingSource.DataSource = typeof(ScanPmrWinForm.ViewModel.PmrElementClass);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Indice";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.OrangeRed;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.FillWeight = 71.94846F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Indice";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Fronte";
            this.dataGridViewImageColumn1.FillWeight = 132.692F;
            this.dataGridViewImageColumn1.HeaderText = "Fronte";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Retro";
            this.dataGridViewImageColumn2.FillWeight = 132.692F;
            this.dataGridViewImageColumn2.HeaderText = "Retro";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Codice";
            this.dataGridViewTextBoxColumn2.FillWeight = 132.692F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Codice";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // MonitorPmrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 500);
            this.Controls.Add(this.tabMonitorControl);
            this.Name = "MonitorPmrForm";
            this.Text = "MonitorPmrForm";
            this.tabMonitorControl.ResumeLayout(false);
            this.tabScartiScansione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScarti)).EndInit();
            this.tabInserimento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInserimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmrElementClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMonitorControl;
        private System.Windows.Forms.TabPage tabScartiScansione;
        private System.Windows.Forms.TabPage tabInserimento;
        private System.Windows.Forms.DataGridView dataGridViewScarti;
        private System.Windows.Forms.BindingSource pmrElementClassBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn indiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn fronteDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn retroDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ErrorScan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ErrorValidation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ErrorInsert;
        private System.Windows.Forms.DataGridView dataGridViewInserimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}