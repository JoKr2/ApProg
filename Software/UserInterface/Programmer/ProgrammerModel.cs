using System.Collections.Generic;
using System.ComponentModel;
using ApProg.UserInterface.Shell;
using ApProg.Utilities;

namespace ApProg.UserInterface.Programmer
{
    /// <summary>
    /// Very dumb model containing presented data & commands
    /// </summary>
    public class ProgrammerModel : INotifyPropertyChanged
    {
        private bool myEnabled;
        private bool myMenuEnabled;
        private string myConnectionState = Resources.Connect;
        private ComPortParams myConnectionParams = new ComPortParams();
        private string myDeviceIdentifier;
        private IEnumerable<uint> myDocument;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Enabled
        {
            get { return myEnabled; }
            set
            {
                myEnabled = value;
                FirePropertyEvent("Enabled");
            }
        }

        public bool MenuEnabled
        {
            get { return myMenuEnabled; }
            set
            {
                myMenuEnabled = value;
                FirePropertyEvent("MenuEnabled");
            }
        }

        public string ConnectionState
        {
            get { return myConnectionState; }
            set
            {
                myConnectionState = value;
                FirePropertyEvent("ConnectionState");
            }
        }

        public ComPortParams ConnectionParams
        {
            get { return myConnectionParams; }
            set
            {
                myConnectionParams = value;
                FirePropertyEvent("ConnectionParams");
            }
        }

        public string DeviceIdentifier
        {
            get { return myDeviceIdentifier; }
            set
            {
                myDeviceIdentifier = value;
                FirePropertyEvent("DeviceIdentifier");
            }
        }

        public IEnumerable<uint> Document
        {
            get { return myDocument; }
            set
            {
                myDocument = value;
                FirePropertyEvent("Document");
            }
        }

        public string FileName { get; set; }

        public UiCommand OpenFileCmd { get; set; }

        public UiCommand SaveFileCmd { get; set; }

        public UiCommand HardwareInfoCmd { get; set; }

        public UiCommand ConnectionCmd { get; set; }

        public UiCommand ReadDeviceCmd { get; set; }

        public UiCommand WriteDeviceCmd { get; set; }

        public UiCommand EraseDeviceCmd { get; set; }

        public UiCommand CloseApplicationCmd { get; set; }

        private void FirePropertyEvent(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
