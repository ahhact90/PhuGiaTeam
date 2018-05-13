using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuocTrangBi
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
            //Application.Run(new From_CauHinh.Frm_Setting());
            Application.Run(new From_ChucNang.Frm_NuocSX());
            //Application.Run(new FrmTest());
        }
    }

}
