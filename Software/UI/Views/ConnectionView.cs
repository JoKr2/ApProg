using System;
using System.Windows.Forms;
using ApProg.Utilities;

namespace ApProg.UI.Views
{
    public partial class ConnectionView : Form
    {
        public ConnectionView()
        {
            InitializeComponent();
        }

        public void BindTo(ComPortParams portParams)
        {
            if(portParams == null)
                throw new ArgumentNullException("portParams");

            cbPortId.DataSource = portParams.AvailablePorts;
            cbPortId.DataBindings.Add("Text", portParams, "PortId");
            cbBaudRate.DataSource = portParams.BaudRates;
            cbBaudRate.DataBindings.Add("Text", portParams, "BaudRate");
            cbData.DataSource = portParams.DataValues;
            cbData.DataBindings.Add("Text", portParams, "DataBits");
            cbParity.DataSource = portParams.AvailableParity;
            cbParity.DataBindings.Add("Text", portParams, "Parity");
            cbStop.DataSource = portParams.AvailableStopBits;
            cbStop.DataBindings.Add("Text", portParams, "StopBits");
        }
    }
}
