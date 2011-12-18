using System;
using System.Windows.Forms;
using ApProg.Utilities;

namespace ApProg.UI.Views
{
    public partial class ProgrammerView : Form, IProgrammerView
    {
        public string Document
        {
            get { return txtMessage.Text; }
            set { txtMessage.Text = value; }
        }

        public IProgrammerViewObserver Presenter { get; set; }

        public ProgrammerView()
        {
            InitializeComponent();
        }

        private void OnBtnFileClick(object sender, EventArgs e)
        {
            var aDialog = new OpenFileDialog();
            if(aDialog.ShowDialog() == DialogResult.OK)
                txtFile.Text = aDialog.FileName;
        }

        private void OnBtnConnectClick(object sender, EventArgs e)
        {
            btnConnect.Text = Presenter.ConnectSelected() ? "Disconnect" : "Connect";
        }

        private void OnReadDevIdClick(object sender, EventArgs e)
        {
            Presenter.ReadDevIdSelected();
        }

        private void OnReadAppIdClick(object sender, EventArgs e)
        {
            Presenter.ReadAppIdSelected();
        }

        private void OnEraseDevicClick(object sender, EventArgs e)
        {
            Presenter.EraseDeviceSelected();
        }

        private void OnWriteDeviceClick(object sender, EventArgs e)
        {
            Presenter.WriteFlashSelected(txtFile.Text);
        }

        private void OnReadDeviceClick(object sender, EventArgs e)
        {
            Presenter.ReadFlashSelected();
        }

        public void InformUser(string message)
        {
            MessageBox.Show(message);
        }

        public bool AskUserForConfiguration(ComPortParams port)
        {
            ConnectionView view = new ConnectionView();
            view.BindTo(port);
            return view.ShowDialog() == DialogResult.OK;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
            txtMessage.ScrollToCaret();
        }
    }
}
