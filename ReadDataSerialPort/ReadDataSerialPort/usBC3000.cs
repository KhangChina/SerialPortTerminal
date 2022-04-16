using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadDataSerialPort
{
    public partial class usBC3000 : DevExpress.XtraEditors.XtraUserControl
    {
        public usBC3000()
        {
            InitializeComponent();
        }
        private static usBC3000 _instance;
        public static usBC3000 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBC3000();
                return _instance;
            }
        }
        public void BC3000(string txt)
        {
            if (txt.Length > 100)
            {
                string text = Strings.Mid(txt, 2, 3);
                if (text == "AAA")
                {
                    string STT = "";
                    STT = Strings.Mid(txt, 11, 12);
                    STT = Utility.ZeroTrimSID(STT);
                    string stt = STT;
                    textBox2.Text += "Stt: " + stt + "\r\n";
                    text = Strings.Mid(txt, 24, 8);
                    string getTime = string.Concat(new string[]
                    {
                Strings.Mid(text, 5, 4),
                "/",
                Strings.Mid(text, 1, 2),
                "/",
                Strings.Mid(text, 3, 2)
                    });
                    string ngayXN = string.Concat(new string[]
                    {
                Strings.Mid(text, 1, 2),
                "/",
                Strings.Mid(text, 3, 2),
                "/",
                Strings.Mid(text, 5, 5)
                    });
                    string kq;
                    string ketQua;
                    textBox2.Text += "Time: " + getTime + "\r\n";
                    kq = Strings.Mid(txt, 36, 5).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 100.0);
                    textBox2.Text += "WBC: " + ketQua + "\r\n";
                    kq = Strings.Mid(txt, 42, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 1000.0);
                    textBox2.Text += "LYM#: " + ketQua + "\r\n";
                    //maXN = this.CD1600MaMay[15].ToString();
                    kq = Strings.Mid(txt, 46, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 1000.0);
                    textBox2.Text += "MID#: " + ketQua + "\r\n";
                    //maXN = this.CD1600MaMay[16].ToString();
                    kq = Strings.Mid(txt, 49, 3);
                    try
                    {
                        ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                        textBox2.Text += "GRAN# " + ketQua + "\r\n";
                    }
                    catch (Exception)
                    {
                        ketQua = kq;
                        textBox2.Text += "GRAN# " + ketQua + "\r\n";
                    }
                    kq = Strings.Mid(txt, 52, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "LYM: " + ketQua + "\r\n"; //1
                    kq = Strings.Mid(txt, 55, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "MID: " + ketQua + "\r\n"; //2
                    kq = Strings.Mid(txt, 58, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "GRAN: " + ketQua + "\r\n"; //3
                    kq = Strings.Mid(txt, 61, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 100.0);
                    textBox2.Text += "RBC: " + ketQua + "\r\n"; //4
                    kq = Strings.Mid(txt, 64, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "HGB: " + ketQua + "\r\n"; //5
                    kq = Strings.Mid(txt, 82, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "HCT: " + ketQua + "\r\n"; //6
                    kq = Strings.Mid(txt, 71, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "MCV: " + ketQua + "\r\n"; //7               
                    kq = Strings.Mid(txt, 75, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "MCH: " + ketQua + "\r\n"; //8
                    kq = Strings.Mid(txt, 67, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "MCHC: " + ketQua + "\r\n"; //9
                    kq = Strings.Mid(txt, 79, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "RDW: " + ketQua + "\r\n"; //10
                    kq = Strings.Mid(txt, 85, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N0}", double.Parse(Strings.RTrim(kq)));
                    textBox2.Text += "PLT: " + ketQua + "\r\n"; //11
                    kq = Strings.Mid(txt, 89, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "MPV: " + ketQua + "\r\n"; //12
                    kq = Strings.Mid(txt, 95, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N3}", double.Parse(Strings.RTrim(kq)) / 1000.0);
                    textBox2.Text += "PCT: " + ketQua + "\r\n";
                    kq = Strings.Mid(txt, 92, 3).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "PDW: " + ketQua + "\r\n";
                    kq = Strings.Mid(txt, 98, 4).Replace("*", "0");
                    ketQua = string.Format("{0:N1}", double.Parse(Strings.RTrim(kq)) / 10.0);
                    textBox2.Text += "RDW-SD: " + ketQua + "\r\n";
                }
            }

        }
     
        private void btnConvert_Click(object sender, EventArgs e)
        {
            BC3000(mmRawData.Text.Replace("?", "*"));
        }

        private  string ConvertAsciiToUTF8(string inAsciiString)
        {
            // Create encoding ASCII.
            Encoding inAsciiEncoding = Encoding.ASCII;
            // Create encoding UTF8.
            Encoding outUTF8Encoding = Encoding.UTF8;
            // Convert the input string into a byte[].
            byte [] inAsciiBytes = inAsciiEncoding.GetBytes(inAsciiString);
            // Conversion string in ASCII encoding to UTF8 encoding byte array.
            byte [] outUTF8Bytes = Encoding.Convert(inAsciiEncoding, outUTF8Encoding, inAsciiBytes);
            // Convert the byte array into a char[] and then into a string.
            char [] inUTF8Chars = new char [outUTF8Encoding.GetCharCount(outUTF8Bytes, 0, outUTF8Bytes.Length)];
            outUTF8Encoding.GetChars(outUTF8Bytes, 0, outUTF8Bytes.Length, inUTF8Chars, 0);
            string  outUTF8String = new string (inUTF8Chars);
            return outUTF8String;
        }
    }
}
