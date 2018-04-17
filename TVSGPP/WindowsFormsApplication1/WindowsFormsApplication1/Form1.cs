using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Globalization;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetCDKey(string Source)
        {
            string text = "";
            string[] array = new string[26]
		{
			"H",
			"I",
			"N",
			"H",
			"Q",
			"U",
			"R",
			"N",
			"G",
			"P",
			"L",
			"K",
			"J",
			"H",
			"G",
			"F",
			"D",
			"S",
			"A",
			"Z",
			"X",
			"C",
			"V",
			"B",
			"N",
			"M"
		};
            string[] array2 = new string[26]
		{
			"A",
			"W",
			"N",
			"Y",
			"Q",
			"U",
			"A",
			"N",
			"G",
			"P",
			"O",
			"H",
			"L",
			"K",
			"N",
			"A",
			"S",
			"D",
			"F",
			"C",
			"V",
			"Z",
			"X",
			"M",
			"J",
			"B"
		};
            if (Source != "")
            {
                text = this.CryptographyMD5(Source);               
                char[] array3 = text.ToCharArray(0, text.Trim().Length);
               
                for (int i = 0; i < array3.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        text += array3[i];
                    }
                }
                MessageBox.Show(text);
                char[] array4 = text.Trim().ToCharArray(0, text.Trim().Length);
                text = "";
                for (int j = 0; j < 20; j++)
                {
                    text = ((j % 2 != 1) ? (text + array2[int.Parse(array3[j].ToString())]) : (text + array[int.Parse(array3[j].ToString())]));
                }
            }
            MessageBox.Show(text);
            return text;
        }

        public string CryptographyMD5(string source)
        {
            string text = "";
            try
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(source);
                byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
                byte[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    byte b = array2[i];
                    text += int.Parse(b.ToString(), NumberStyles.HexNumber).ToString();
                }
            }
            catch
            {
            }
            return text;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = GetCDKey(txtNhap.Text.Trim());
        }


    }
}
