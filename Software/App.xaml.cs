using System.Windows;
using System.Windows.Threading;
using ApProg.Infrastructure;

namespace ApProg
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs startupArgs)
        {
            base.OnStartup(startupArgs);
            DispatcherUnhandledException += OnDispatcherUnhandledException;
            new Bootstrapper();
        }

        private static void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            MessageBox.Show(args.Exception.Message);
        }
    }
}
