using System;
using System.ComponentModel;
using System.IO;
using ApProg.Icsp;
using ApProg.UserInterface.Shell;
using ApProg.Utilities;

namespace ApProg.UserInterface.Programmer
{
    /// <summary>
    /// Handles interaction between user and Icsp
    /// </summary>
    public class ProgrammerPresenter
    {
        private readonly IScreen myScreen;
        private readonly ProgrammerModel myModel = new ProgrammerModel();
        private readonly IIcspService myIcspService;
        private readonly IShell myShell;
        private readonly IScreen myInfoScreen = new HardwareInfoScreen();

        public ProgrammerPresenter(IScreen screen, IIcspService icspService, IShell shell)
        {
            if(screen == null)
                throw new ArgumentNullException("screen");
            if(icspService == null)
                throw new ArgumentNullException("icspService");

            myScreen = screen;
            myIcspService = icspService;
            myShell = shell;
            BindCommands();
        }

        private void BindCommands()
        {
            myModel.HardwareInfoCmd = new UiCommand(HardwareDetailsPressed);
            myModel.ConnectionCmd = new UiCommand(ConnectPressed);
            myModel.OpenFileCmd = new UiCommand(FileOpenInvoked);
            myModel.SaveFileCmd = new UiCommand(FileSaveInvoked);
            myModel.ReadDeviceCmd = new UiCommand(ReadDevicePressed);
            myModel.WriteDeviceCmd = new UiCommand(WriteDevicePressed);
            myModel.EraseDeviceCmd = new UiCommand(EraseDevicePressed);
            myModel.CloseApplicationCmd = new UiCommand(par => myShell.Close());

            myShell.DataContext = myModel;
            myShell.NavigationScreen.DataContext = myModel;
            myScreen.DataContext = myModel;
        }

        private void FileOpenInvoked(object obj)
        {
            string fileName = myShell.AskUserForFileName(true);
            if (string.IsNullOrEmpty(fileName))
                return;

            myModel.FileName = fileName;
            Memory memory = HexReader.ReadHexFile(fileName);
            myModel.Document = memory.Instructions;
        }

        private void FileSaveInvoked(object obj)
        {
            //ToDo...
        }

        public void ProgrammerSelected(string programmerId)
        {
            // ToDo...
        }

        private void HardwareDetailsPressed(object obj)
        {
            myShell.AddScreen(myInfoScreen, "Hardware Details");
        }

        private void ConnectPressed(object param)
        {
            if (myIcspService.IsConnected)
            {
                myIcspService.Disconnect();
                myShell.RemoveScreen(myScreen);
                myModel.MenuEnabled = false;
                myModel.ConnectionState = Resources.Connect;
                return;
            }

            if (string.IsNullOrEmpty(myModel.ConnectionParams.PortId))
            {
                myShell.InformUser("Invalid Port Identifier!");
                return;
            }

            try
            {
                if (myIcspService.Connect(myModel.ConnectionParams))
                {
                    myShell.AddScreen(myScreen, "PIC24FJXX Programmer");
                    myModel.MenuEnabled = true;
                    myModel.ConnectionState = Resources.Disconnect;
                    ReadDevIdSelected();
                }
            }
            catch(TimeoutException)
            {
                myShell.InformUser("Programmer does not respond. Please check connection.");
            }
        }

        public void ReadDevIdSelected()
        {
            myModel.DeviceIdentifier = new IcspFacade(myIcspService).ReadDeviceId();
            //ToDo - resolve device id and show familiar device name
        }

        public void ReadAppIdSelected()
        {
             //myView.Document += new IcspFacade(myIcspService).ReadApplicationId();
        }

        private void ReadDevicePressed(object obj)
        {
            myShell.InformUser("This function is it available yet");
        }

        private void WriteDevicePressed(object obj)
        {
            if (!File.Exists(myModel.FileName))
            {
                myShell.InformUser("Load hex file first.");
                return;
            }

            myShell.ShowProgressBar(true);
            Memory memory = HexReader.ReadHexFile(myModel.FileName);

            // takes a bit longer so... (execute in background)
            var worker = new BackgroundWorker();
            worker.DoWork += (s, e) => new IcspFacade(myIcspService).WriteFlash(
                ((Memory)e.Argument).Instructions, (val, str) => myShell.UpdateProgress(val, str));
            worker.RunWorkerCompleted += (s,e) => myShell.ShowProgressBar(false);
            worker.RunWorkerAsync(memory);
        }

        private void EraseDevicePressed(object obj)
        {
            new IcspFacade(myIcspService).EraseFlash();
            myShell.InformUser("Device has been erased");
        }
    }
}
