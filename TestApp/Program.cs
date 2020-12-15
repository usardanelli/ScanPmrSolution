﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScanPmrWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.BasicConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormLogin());
            Application.Run(new MainForm(new ViewModel.UserViewModel(Environment.UserName,Environment.UserDomainName)));
        }
    }
}
