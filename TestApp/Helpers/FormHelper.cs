using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScanPmrWinForm.Helpers
{
    public static class FormHelper
    {

        public static void OpenForm<MyForm>(Panel panel) where MyForm : Form, new()
        {
            Form form;
            form = panel.Controls.OfType<MyForm>().FirstOrDefault();

            if (form == null)
            {
                form = new MyForm();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panel.Controls.Add(form);
                panel.Tag = form;
                form.Show();
                form.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                form.BringToFront();
            }


        }
    }
}
