using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTL
{
    public static class MH
    {
        public static string CreateMD5(string input)
        {
            System.Security.Cryptography.MD5 mD = System.Security.Cryptography.MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] array = mD.ComputeHash(bytes);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }
}
