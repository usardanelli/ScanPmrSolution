using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScanPmrWinForm.ViewModel;

namespace ScanPmrWinForm.Views
{
    public partial class MonitorPmrForm : Form
    {
        public MonitorPmrForm(List<PmrElementClass> pmrElements)
        {
            InitializeComponent();

            dataGridViewScarti.DataSource = pmrElements.Where(x => x.InsertSuccess == false).ToList();
            dataGridViewInserimento.DataSource = pmrElements.Where(x => x.InsertSuccess == true).ToList();
            dataGridViewScarti.Columns[0].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridViewInserimento.Columns[0].DefaultCellStyle.BackColor = Color.Green;
            //foreach (TabPage _Page in tabMonitorControl.TabPages)
            //{
            //    _Page.AutoScroll = true;
            //    _Page.AutoScrollMargin = new System.Drawing.Size(20, 20);
            //    _Page.AutoScrollMinSize = new System.Drawing.Size(_Page.Width, _Page.Height);
            //}
        }
    }
}
