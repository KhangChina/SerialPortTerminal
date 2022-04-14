using DevExpress.XtraEditors;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.IO;

namespace ReadDataSerialPort
{
    public partial class usNewMachine : DevExpress.XtraEditors.XtraUserControl
    {
        private static usNewMachine _instance;
        public static usNewMachine Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usNewMachine();
                return _instance;
            }
        }
        SerialPort mySerialPort;
        public usNewMachine()
        {
            InitializeComponent();
            LoadCom();
            btnDisconnect.Enabled = false;
            //Init BaudRate
            cbxBaudRate.Properties.Items.Add("300");
            cbxBaudRate.Properties.Items.Add("600");
            cbxBaudRate.Properties.Items.Add("1200");
            cbxBaudRate.Properties.Items.Add("2400");
            cbxBaudRate.Properties.Items.Add("9600");
            cbxBaudRate.Properties.Items.Add("14400");
            cbxBaudRate.Properties.Items.Add("19200");
            cbxBaudRate.Properties.Items.Add("38400");
            cbxBaudRate.Properties.Items.Add("57600");
            cbxBaudRate.Properties.Items.Add("115200");
            cbxBaudRate.SelectedIndex = 4;
            //Init DataBits
            spDataBits.Value = 8;
            //Init Parity
            cbxParity.Properties.Items.Add("None");
            cbxParity.Properties.Items.Add("Even");
            cbxParity.Properties.Items.Add("Space");
            cbxParity.Properties.Items.Add("Odd");
            cbxParity.Properties.Items.Add("Mark");
            cbxParity.SelectedIndex = 0;
            // Init StopBits
            // cbxStopBits.Properties.Items.Add("None");
            cbxStopBits.Properties.Items.Add("One");
            cbxStopBits.Properties.Items.Add("Two");
            cbxStopBits.Properties.Items.Add("OnePointFive");
            cbxStopBits.SelectedIndex = 0;
            //Init Handshake
            cbxHandshake.Properties.Items.Add("None");
            cbxHandshake.Properties.Items.Add("RequestToSend");
            cbxHandshake.Properties.Items.Add("RequestToSendXOnXOff");
            cbxHandshake.Properties.Items.Add("XOnXOff");
            cbxHandshake.SelectedIndex = 0;

            //Init RtsEnable
            cbxRtsEnable.Properties.Items.Add("True");
            cbxRtsEnable.Properties.Items.Add("False");
            cbxRtsEnable.SelectedIndex = 0;
        }
        private void btnLoadCom_Click(object sender, EventArgs e)
        {
            LoadCom();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string namePort = cbxPortCom.Text;
            if (namePort.Trim().Length <= 3)
            {
                XtraMessageBoxArgs mess = new XtraMessageBoxArgs();
                mess = new XtraMessageBoxArgs();
                mess.Caption = "Validate !!!";
                mess.Text = "Lenght Com >3";
                mess.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(mess);
                return;

            }
            int BaudRate = int.Parse(cbxBaudRate.Text);
            int DataBits = int.Parse(spDataBits.Value.ToString());
            mySerialPort = new SerialPort(namePort);
            switch (cbxParity.Text)
            {
                case ("None"):
                    mySerialPort.Parity = Parity.None;
                    break;
                case ("Even"):
                    mySerialPort.Parity = Parity.Even;
                    break;
                case ("Space"):
                    mySerialPort.Parity = Parity.Space;
                    break;
                case ("Odd"):
                    mySerialPort.Parity = Parity.Odd;
                    break;
                case ("Mark"):
                    mySerialPort.Parity = Parity.Mark;
                    break;
            }
            switch (cbxStopBits.Text)
            {
                //case ("None"):
                //    mySerialPort.StopBits = StopBits.None;
                //    break;
                case ("One"):
                    mySerialPort.StopBits = StopBits.One;
                    break;
                case ("Two"):
                    mySerialPort.StopBits = StopBits.Two;
                    break;
                case ("OnePointFive"):
                    mySerialPort.StopBits = StopBits.OnePointFive;
                    break;
            }
            switch (cbxHandshake.Text)
            {
                case ("None"):
                    mySerialPort.Handshake = Handshake.None;
                    break;
                case ("One"):
                    mySerialPort.Handshake = Handshake.RequestToSend;
                    break;
                case ("Two"):
                    mySerialPort.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
                case ("OnePointFive"):
                    mySerialPort.Handshake = Handshake.XOnXOff;
                    break;

            }
            mySerialPort.RtsEnable = bool.Parse(cbxRtsEnable.Text);

            XtraMessageBoxArgs messageBox = new XtraMessageBoxArgs();
            messageBox.AutoCloseOptions.Delay = 10000;
            messageBox.DefaultButtonIndex = 1;
            messageBox.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            messageBox.Caption = "You sure connect " + namePort + " ?";
            messageBox.Text = "This message closes automatically after 10 seconds.";
            messageBox.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            if (XtraMessageBox.Show(messageBox) == DialogResult.OK)
            {

                mmConfig.Text += "---------Connect--------\r\n";
                mmConfig.Text += "Name Com: " + namePort + "\r\n";
                mmConfig.Text += "BaudRate: " + BaudRate + "\r\n";
                mmConfig.Text += "DataBits: " + DataBits + "\r\n";
                mmConfig.Text += "Parity: " + cbxParity.Text + "\r\n";
                mmConfig.Text += "StopBits: " + cbxStopBits.Text + "\r\n";
                mmConfig.Text += "RtsEnable: " + cbxRtsEnable.Text + "\r\n";
                mmConfig.Text += "Handshake: " + cbxHandshake.Text + "\r\n";
                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                try
                {
                    mySerialPort.Open();
                    if (mySerialPort.IsOpen == true)
                    {
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        mmReceived.Text += "Received data from: " + namePort + " -----------------\r\n";
                    }
                    else
                    {
                        messageBox = new XtraMessageBoxArgs();
                        messageBox.Caption = "Not connect " + namePort + " ?";
                        messageBox.Text = "Re-check config com";
                        messageBox.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(messageBox);
                    }
                }
                catch (Exception ex)
                {

                    messageBox = new XtraMessageBoxArgs();
                    messageBox.Caption = "Not connect " + namePort + " !";
                    messageBox.Text = "Re-check config Com! Error: " + ex;
                    messageBox.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(messageBox);
                    mmConfig.Text += "---------Stop----------\r\n";
                }


            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            //Read Text
            var indata = sp.ReadExisting();
            mmReceived.Invoke(new Action(() => { mmReceived.Text += indata; }));
            // Read Hex
            int bytesToRead = sp.BytesToRead;
            int bytes = sp.BytesToRead;
            byte[] buffer = new byte[bytes];
            if (sp.BytesToRead > 1)
            {
                sp.Read(buffer, 0, bytes);
            }

            foreach (byte item in buffer)
            {
                mmHex.Invoke(new Action(() => { mmHex.Text += item + " "; }));
            }
            //Read byte[] to string
            byte[] array = new byte[bytesToRead];
            sp.Read(array, 0, bytesToRead);
            string res = Utility.ByteArrayToHexString(array);
            mmByteToString.Invoke(new Action(() => { mmByte.Text += res + "\r\n"; }));
            

        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen == true)
            {
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                mySerialPort.Close();
                mmConfig.Text += "---------Stop--------\r\n";
                mmReceived.Text += "Stop Received data -----------------\r\n";
            }

        }
        void LoadCom()
        {
            cbxPortCom.Properties.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbxPortCom.Properties.Items.Add(port);
            }
            cbxPortCom.SelectedIndex = -1;
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdgSaveFile = new SaveFileDialog();
            sfdgSaveFile.Title = "Browse Text Files";
            sfdgSaveFile.DefaultExt = "txt";
            sfdgSaveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfdgSaveFile.FilterIndex = 2;
            sfdgSaveFile.RestoreDirectory = true;
            if (sfdgSaveFile.ShowDialog() == DialogResult.OK)
            {
                string nameFile = sfdgSaveFile.FileName;
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(nameFile)))
                {
                    outputFile.Write("-------------Config----------------------------------------\r\n");
                    outputFile.Write(mmConfig.Text);
                    outputFile.Write("-------------Text------------------------------------------\r\n");
                    outputFile.Write(mmReceived.Text);
                    outputFile.Write("-------------Hex-------------------------------------------\r\n");
                    outputFile.Write(mmHex.Text);
                    outputFile.Write("-------------Byte []---------------------------------------\r\n");
                    outputFile.Write(mmByte.Text);
                    outputFile.Write("-------------Convent byte [] => String---------------------\r\n");
                    outputFile.Write(mmByteToString.Text);
                }
            }
        }
    }
}
