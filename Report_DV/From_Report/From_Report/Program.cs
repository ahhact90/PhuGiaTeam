using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace From_Report
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
            //Application.Run(new From_Dstore.From_Duoc_AnhXa());
            //Application.Run(new From_CauHinh.FrmMH());
            //Application.Run(new Frm_TiepDon());
            //Application.Run(new FrmService())
                 Application.Run(new FrmMain());
            //Application.Run(new FrmReception());
                 Application.Run(new FrmSearch());
            //Application.Run(new From_CV3360.CV3360_CT());

            //Application.Run(new From_Dstore.Frm_Group_type());
            
        }
    }
}
