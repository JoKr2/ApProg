using System;
using System.Windows.Forms;
using ApProg.Icsp;
using ApProg.UI.Presenters;
using ApProg.UI.Views;
using ApProg.Utilities;

namespace ApProg
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnErrorOccured;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProgrammerView screen = new ProgrammerView();
            new ProgrammerPresenter(screen, new IcspService());
            Application.Run(screen);
        }

        /// <summary>
        /// Global exception handler
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="args">The detailed information about event</param>
        static void OnErrorOccured(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show(((Exception)args.ExceptionObject).Message);
            Application.Exit();
        }
    }
}
