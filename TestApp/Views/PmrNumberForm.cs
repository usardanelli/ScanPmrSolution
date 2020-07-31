using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScanPmrWinForm.Views
{
    public partial class PmrNumberForm : Form
    {
        public int PmrNumber { get; private set; }
        public PmrNumberForm()
        {
            InitializeComponent();
        }


        private void numericPmr_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                int number = decimal.ToInt32(numericPmr.Value);
                if (number > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    PmrNumber = number;
                }
                else
                    lblerrmsg.Text = "Inserire il numero di PMR da scansire";
            }
            catch (OverflowException ex)
            {
                lblerrmsg.Text = string.Format("{0}: {1}", ex.GetType().Name, numericPmr.Value);
            }
        }
    }
}
