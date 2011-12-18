using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ApProg.Icsp;
using ApProg.UI.Views;
using ApProg.Utilities;

namespace ApProg.UI.Presenters
{
    public class ProgrammerPresenter : IProgrammerViewObserver
    {
        protected readonly IProgrammerView myView;
        protected readonly IIcspService myIcspService;

        public ProgrammerPresenter(IProgrammerView view, IIcspService service)
        {
            if(view == null)
                throw new ArgumentNullException("view");

            if(service == null)
                throw new ArgumentNullException("service");

            myView = view;
            myView.Presenter = this;
            myIcspService = service;
        }

        public bool ConnectSelected()
        {
            if (myIcspService.IsConnected)
                myIcspService.Disconnect();

            myView.Document = string.Empty;
            ComPortParams portConfig = new ComPortParams();
            
            if(myView.AskUserForConfiguration(portConfig))
                return myIcspService.Connect(portConfig);
            return false;
        }

        public void DisconnectSelected()
        {
            if(myIcspService.IsConnected)
                myIcspService.Disconnect();
        }

        public void ReadDevIdSelected()
        {
            if (myIcspService.IsConnected)
                myView.Document += new IcspFacade(myIcspService).ReadDeviceId();
            else
                myView.InformUser("You must connect to device first.");
        }

        public void ReadAppIdSelected()
        {
            if (myIcspService.IsConnected)
                myView.Document += new IcspFacade(myIcspService).ReadApplicationId();
            else
                myView.InformUser("You must connect to device first.");
        }

        public void EraseDeviceSelected()
        {
            if (myIcspService.IsConnected)
            {
                new IcspFacade(myIcspService).EraseFlash();
                myView.Document += string.Format(Resources.DeviceErasedMsg);
            }
            else
                myView.InformUser("You must connect to device first.");
        }

        public void ReadFlashSelected()
        {
            if(myIcspService.IsConnected)
                new IcspFacade(myIcspService).ReadFlash(str => myView.Document += str);
            else
                myView.InformUser("You must connect to device first.");
        }

        public void WriteFlashSelected(string filename)
        {
            if (!File.Exists(filename))
            {
                myView.InformUser(Resources.HexFileRequestMsg);
                return;
            }

            if (!myIcspService.IsConnected)
            {
                myView.InformUser("You must connect to device first.");
                return;
            }

            Memory memory = HexReader.ReadHexFile(filename);

            // takes a bit longer so... (execute in background)
            Thread worker = new Thread(() => new IcspFacade(myIcspService).WriteFlash(
                memory.Instructions, str => ((Control)myView).Invoke((Action)(() => myView.Document += str))));
            worker.IsBackground = true;
            worker.Start();
        }
    }
}
