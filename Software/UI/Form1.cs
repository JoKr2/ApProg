using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ApProg.Icsp;
using ApProg.Properties;
using ApProg.Utilities;

namespace ApProg.UI
{
    public partial class Form1 : Form
    {
        private readonly IcspService myIcspService;
   
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IcspService adapter) : this()
        {
            myIcspService = adapter;
        }

        private void OnBtnFileClick(object sender, EventArgs e)
        {
            var aDialog = new OpenFileDialog();
            if(aDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = aDialog.FileName;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if(myIcspService.IsConnected)
                myIcspService.Disconnect();
        }

        private void OnBtnConnectClick(object sender, EventArgs e)
        {
            if(myIcspService.IsConnected)
            {
                myIcspService.Disconnect();
                btnConnect.Text = "Connect";
            }
            else
            {
                txtMessage.Text = string.Empty;
                if (myIcspService.Connect())
                {
                    btnConnect.Text = "Disconnect";
                }
                else
                    myIcspService.Disconnect();
            }
        }

        private void OnReadDevIdClick(object sender, EventArgs e)
        {
            txtMessage.Text += new IcspFacade(myIcspService).ReadDeviceId();
        }

        private void OnReadAppIdClick(object sender, EventArgs e)
        {
            txtMessage.Text += new IcspFacade(myIcspService).ReadApplicationId();
        }

        private void OnEraseDevicClick(object sender, EventArgs e)
        {
            new IcspFacade(myIcspService).EraseFlash();
        }

        private void OnWriteDeviceClick(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show(Resources.HexFileRequestMsg);
                return;
            }

            Memory memory = HexReader.ReadHexFile(txtFile.Text);
            
            // takes a bit longer so... (execute in background)
            Thread worker = new Thread(() => new IcspFacade(myIcspService).WriteFlash(
                memory.Instructions, str => Invoke((Action)(() => txtMessage.Text += str))));
            worker.IsBackground = true;
            worker.Start();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
            txtMessage.ScrollToCaret();
        }

        private void OnReadDeviceClick(object sender, EventArgs e)
        {
            IcspFacade facade = new IcspFacade(myIcspService);
            facade.EnterIcsp();
            foreach(uint instr in facade.ReadInstructions(0))
            {
                txtMessage.Text += string.Format("Instruction read: 0x{0:X8}\r\n", instr);
            }
            facade.ExitIcsp();
        }
    }
}
