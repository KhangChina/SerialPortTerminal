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
    public partial class usAU400 : DevExpress.XtraEditors.XtraUserControl
    {
		private static usAU400 _instance;
		public static usAU400 Instance
		{
			get
			{
				if (_instance == null)
					_instance = new usAU400();
				return _instance;
			}
		}
		public usAU400()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
			Au400(mmData.Text);

		}
		public void Au400(string textMachines)
		{
			string kq = "";
			//string textMachines = "Data in put";
			//this.data[PN] = "";
			if (Strings.InStr(1, textMachines, "\u0002RE00\u0003", CompareMethod.Text) > 0 || Strings.InStr(1, textMachines, "\u0002DE00\u0003", CompareMethod.Text) > 0 || Strings.InStr(1, textMachines, Strings.Chr(3).ToString(), CompareMethod.Text) > 0 || Strings.Len(textMachines) > 15)
			{
				//this.kq = this.kq + textMachines;
				//textMachines = this.kq;
				//this.kq = "";
				int num = Strings.InStr(1, textMachines, "\u0002DB00\u0003", CompareMethod.Text);
				if (num > 0)
				{
					textMachines = Strings.Right(textMachines, Strings.Len(textMachines) - num - 3 - 2);
				}
				num = Strings.InStr(1, textMachines, "\u0002RB00\u0003", CompareMethod.Text);
				if (num > 0)
				{
					textMachines = Strings.Right(textMachines, Strings.Len(textMachines) - num - 3 - 2);
				}
				num = Strings.InStr(1, textMachines, "\u0002DE00\u0003", CompareMethod.Text);
				if (num > 0)
				{
					textMachines = Strings.Left(textMachines, num - 1);
				}
				if (textMachines.Length > 0)
				{
					num = Strings.InStr(1, textMachines, Strings.Chr(3).ToString(), CompareMethod.Text);
					string text;
					if (num > 0)
					{
						text = Strings.Left(textMachines, num - 1);
					}
					else
					{
						text = textMachines;
					}
					int num2 = Strings.InStr(1, text, Strings.Chr(2).ToString(), CompareMethod.Text);
					if (num2 > 0)
					{
						text = Strings.Right(text, Strings.Len(text) - num2);
					}
					string @string = Strings.Left(text, 2);
					if (Strings.InStr(1, "D ,d ", @string, CompareMethod.Text) > 0 && Strings.Len(text) > 45)
					{
						string ngayXN = DateTime.Now.ToString("MM/dd/yyyy");
						string getTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
						string stts = Strings.LTrim(Strings.Mid(text, 14, 20));
						text = Strings.Right(text, Strings.Len(text) - 44);
						num2 = Strings.Len(text) / 10;
						if (num2 > 0)
						{
							for (int i = 0; i <= num2 - 1; i++)
							{
								
								//string maXN = this.MaXNMay[PN];
								string ketQua = Strings.LTrim(Strings.Mid(text, i * 10 + 3, 6));
								string text2 = Strings.RTrim(Strings.Mid(text, i * 10 + 1, 2));
								string stt =  stts;
								//this.InsertDulieu(ngayXN, stt, ketQua, PN, text2, maXN, getTime, PN, "", "", "");
								mmDataDecode.Text = ketQua;
								mmDataDecode.Text = "STT: " + stt+"\r\n";
								mmDataDecode.Text = "text2: " + stt + "\r\n";
								mmDataDecode.Text = "Ket Qua: " + ketQua + "\r\n";
							}
						}
					}
					else if (Strings.InStr(1, "R ,", @string, CompareMethod.Text) > 0)
					{
						string RequestSID_O = Strings.Mid(text, 14, 20);
						string RequestSID = Strings.LTrim(Strings.Mid(text, 14, 20));
						string RequestSEQ = Strings.LTrim(Strings.Mid(text, 10, 4));
						string RequestPOS = Strings.LTrim(Strings.Mid(text, 3, 6));
						bool HostQuery = true;
						//this.kq = "";
						//this.RecordData("Host query:" + this.RequestSID[PN], PN);
						//this.SeqstrSent[PN] = 1;
						//this.GetOrder(this.RequestSID[PN], PN);
					}
					textMachines = Strings.Right(textMachines, Strings.Len(textMachines) - num);
					num = Strings.InStr(1, textMachines, Strings.Chr(3).ToString(), CompareMethod.Text);
				}
				else
				{
					kq = kq + textMachines;
				}
			}
		}

	}
}
