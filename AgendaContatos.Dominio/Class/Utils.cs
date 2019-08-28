using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AgendaContatos.Dominio.Class
{
    public static class Utils
    {
        public static string StringListToString(List<string> aStringList, string aTextoQuebra = ", ")
        {
            var strString = new StringBuilder(string.Empty);
            for (var i = 0; i < aStringList.Count; i++)
            {
                if (i == aStringList.Count - 1)
                    strString.Append(aStringList[i]);
                else
                    strString.Append(aStringList[i] + aTextoQuebra);
            }
            return strString.ToString();
        }

        public static string StringArrayToString(string[] aArrayString, string aTextoQuebra = ", ")
        {
            var strString = new StringBuilder(string.Empty);
            for (var i = 0; i < aArrayString.Length; i++)
            {
                if (i == aArrayString.Length - 1)
                    strString.Append(aArrayString[i]);
                else
                    strString.Append(aArrayString[i] + aTextoQuebra);
            }
            return strString.ToString();
        }

        public static string EncodeImage(byte[] image)
        {
            if (image == null) return string.Empty;
            var base64 = Convert.ToBase64String(image);
            return string.Format("data:image/gif;base64,{0}", base64);
        }

        public static byte[] DecodeImage(Stream stream)
        {
            if (stream == null) return null;
            byte[] byteArray = new byte[16 * 1024];
            using (MemoryStream mStream = new MemoryStream())
            {
                int bit;
                while ((bit = stream.Read(byteArray, 0, byteArray.Length)) > 0)
                {
                    mStream.Write(byteArray, 0, bit);
                }
                return mStream.ToArray();                
            }
        }        
    }
}
