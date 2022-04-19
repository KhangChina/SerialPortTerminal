using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadDataSerialPort
{
    public static class Utility
    {
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder stringBuilder = new StringBuilder(data.Length * 3);
            foreach (byte value in data)
            {
                stringBuilder.Append(Convert.ToString(value, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return stringBuilder.ToString().ToUpper();
        }
        public static string ByteArrayToString(byte[] data)
        {
            string text = "";
            foreach (byte b in data)
            {
                if (b == 5)
                {
                    text += "<ENQ>";
                }
                else if (b == 4)
                {
                    text += "<EOT>";
                }
                else if (b == 3)
                {
                    text += "<ETX>";
                }
                else if (b == 2)
                {
                    text += "<STX>";
                }
                else if (b == 10)
                {
                    text += "<LF>";
                }
                else if (b == 13)
                {
                    text += "<CR>";
                }
                else if (b == 124)
                {
                    text += "|";
                }
                else
                {
                    text += (char)b;
                }
            }
            return text.ToString().ToUpper();
        }
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] array = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                array[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            }
            return array;
        }
        public static string ZeroTrimSID(string StrTrim)
        {
            if (Strings.LTrim(StrTrim.Trim()).Length > 0)
            {
                byte b = 1;
                while ((int)b <= Strings.LTrim(StrTrim.Trim()).Length - 1)
                {
                    if (!(Strings.Mid(StrTrim, (int)b, 1) == "0") || !(Strings.Mid(StrTrim.Trim(), (int)(b + 1), 1) != "."))
                    {
                        return StrTrim.Trim();
                    }
                    StrTrim = Strings.Right(StrTrim.Trim(), StrTrim.Trim().Length - (int)b);
                    b = 0;
                    b += 1;
                }
                if (Strings.Mid(StrTrim.Trim(), 1, 1) == "0" && Strings.LTrim(StrTrim.Trim()).Length >= 2)
                {
                    StrTrim = Strings.Right(StrTrim.Trim(), StrTrim.Trim().Length - 1);
                }
                return StrTrim.Trim();
            }
            if (StrTrim.Length != 0)
            {
                return StrTrim;
            }
            return "0";
        }
        public static DateTime parse_datetime(string str)
        {
            if (str != "" && str.Length == 19)
            {
                string text = str.Substring(0, 2);
                string text2 = str.Substring(3, 2);
                string text3 = DateTime.Now.Year.ToString();
                string text4 = str.Substring(9, 2);
                string text5 = str.Substring(12, 2);
                string text6 = str.Substring(16, 2);
                string s = string.Concat(new string[]
                {
                        text3,
                        "/",
                        text2,
                        "/",
                        text,
                        " ",
                        text4,
                        ":",
                        text5,
                        ":",
                        text6
                });
                return DateTime.Parse(s);
            }
            return DateTime.Now;
        }
        public static string parse_datetime_str(string str)
        {
            if (str != "" && str.Length == 19)
            {
                string text = str.Substring(0, 2);
                string text2 = str.Substring(3, 2);
                string text3 = DateTime.Now.Year.ToString();
                string text4 = str.Substring(9, 2);
                string text5 = str.Substring(12, 2);
                string text6 = str.Substring(16, 2);
                return string.Concat(new string[]
                {
                        text,
                        "/",
                        text2,
                        "/",
                        text3,
                        " ",
                        text4,
                        ":",
                        text5,
                        ":",
                        text6
                });
            }
            return DateTime.Now.ToString();
        }
        public static string ConvertByteToString(this byte[] source)
        {
            
            string response = string.Empty;

            foreach (byte b in source)
                response += (Char)b;

            var convertedString = BitConverter.ToString(source);
            return convertedString;
        }
    }
  
}
