﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new WebService_BQP());
            //Application.Run(new WebService());
            Application.Run(new WebService_Update());
            //Application.Run(new CheckBHYT());
            //Application.Run(new BlockInternet());
        }
    }
}
