using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;

namespace UTL
{
    public static class FunctionHelper
    {
        #region Devexpress
        ///// <summary>
        ///// Kiểm tra trùng giá trị của một cột trong Grid, với giá trị input
        ///// </summary>
        //public static Boolean _ValidationSame(this GridView gv, GridColumn colName, string value)
        //{
        //    value = value.ToLower();
        //    for (int i = 0; i < gv.RowCount; i++)
        //    {
        //        if (Convert.ToString(gv.GetRowCellValue(i, colName.FieldName) + string.Empty).ToLower() == value && i != gv.FocusedRowHandle)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Hiển thị màu cho các dòng thêm, sửa, xóa
        /// </summary>
        /// <param name="p_GridView"></param>
        //public static void _SetDefaultColorRowStyle(this GridView p_GridView)
        //{


        //    string _addedColor = "-16256";
        //    string _modifiedColor = "-128";
        //    string _deletedColor = "-64";


        //    // Nếu mã màu rỗng thì return
        //    if (String.IsNullOrEmpty(_addedColor)
        //        && String.IsNullOrEmpty(_modifiedColor)
        //        && String.IsNullOrEmpty(_deletedColor))
        //    {
        //        return;
        //    }

        //    // Set mã màu cho gridView
        //    p_GridView.RowStyle += (sender, e) =>
        //    {
        //        if (e.RowHandle >= 0)
        //        {
        //            var row = p_GridView.GetDataRow(e.RowHandle) as DataRow;

        //            //Row null
        //            if (row == null)
        //            {
        //                return;
        //            }

        //            // Row added
        //            if (row.RowState == DataRowState.Added
        //                && !String.IsNullOrEmpty(_addedColor))
        //            {
        //                e.Appearance.BackColor = ColorTranslator.FromHtml(_addedColor);
        //            }
        //            // Row modified
        //            else if (row.RowState == DataRowState.Modified
        //                && !String.IsNullOrEmpty(_modifiedColor))
        //            {
        //                e.Appearance.BackColor = ColorTranslator.FromHtml(_modifiedColor);
        //            }
        //        }
        //    };

        //    // Row deleted
        //    if (p_GridView.FormatConditions["Deleted"] != null)
        //    {
        //        p_GridView.FormatConditions["Deleted"].Appearance.BackColor =
        //            ColorTranslator.FromHtml(_deletedColor);
        //    }
        //}  
        #endregion
          
        #region Convert Number To String
 
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        private static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }


            return Ktach;

        }

        public static string So_chu(double gNum)
        {
            try
            {
                if (gNum == 0)
                    return "Không đồng";

                string lso_chu = "";
                string tach_mod = "";
                string tach_conlai = "";
                double Num = Math.Round(gNum, 0);
                string gN = Convert.ToString(Num);
                int m = Convert.ToInt32(gN.Length / 3);
                int mod = gN.Length - m * 3;
                string dau = "[+]";

                // Dau [+ , - ]
                if (gNum < 0)
                    dau = "[-]";
                dau = "";

                // Tach hang lon nhat
                if (mod.Equals(1))
                    tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
                if (mod.Equals(2))
                    tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
                if (mod.Equals(0))
                    tach_mod = "000";
                // Tach hang con lai sau mod :
                if (Num.ToString().Length > 2)
                    tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

                ///don vi hang mod 
                int im = m + 1;
                if (mod > 0)
                    lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
                /// Tach 3 trong tach_conlai

                int i = m;
                int _m = m;
                int j = 1;
                string tach3 = "";
                string tach3_ = "";

                while (i > 0)
                {
                    tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                    tach3_ = tach3;
                    lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                    m = _m + 1 - j;
                    if (!tach3_.Equals("000"))
                        lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                    tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                    i = i - 1;
                    j = j + 1;
                }
                if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                    lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
                if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                    lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
                if (lso_chu.Trim().Length > 0)
                    lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

                return lso_chu.ToString().Trim();

            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }

        #endregion

        #region Encrypt Security

        public static string EncryptMD5(string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, str);
                return hash;
            }
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm mã hóa dữ liệu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Encrypt(string key, string content)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(content);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var cTransform = tdes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// Hàm giải mã dữ liệu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Decrypt(string key, string content)
        {
            var toEncryptArray = Convert.FromBase64String(content);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var cTransform = tdes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(
            toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        #endregion
    }
}
