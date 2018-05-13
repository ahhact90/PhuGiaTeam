using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Drug_UnitBLL : DAL.BaseDAL
    {
        //#region Contrustor
        //    //public static string StrConnect = UTL.DataBase.GetConfig();
        //public static string StrConnect;
        //public Drug_UnitBLL(string StrConnect) : base(StrConnect) { }
        //#endregion


        /// <summary>
        /// Mã tự sinh
        /// </summary>
        /// <param name="id"></param>
        /// <returns> id++ </returns>
        public string AddID(string id)
        {
            string s = id.Trim();
            int len = s.Length;
            string con = s.Substring(1);
            string kq = s.Substring(0, 1);
            int so = Convert.ToInt32(con) + 1;
            if (so <= 9)
                kq += '0';
            kq += so;

            return kq;
        }
    }
}
