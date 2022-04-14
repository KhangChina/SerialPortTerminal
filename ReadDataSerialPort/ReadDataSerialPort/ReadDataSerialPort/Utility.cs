using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
