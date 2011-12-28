using ApProg.Icsp;
using ApProg.UserInterface.Programmer;
using ApProg.UserInterface.Shell;

namespace ApProg.Infrastructure
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            var shell = new MainWindow();
            new ProgrammerPresenter(new ProgrammerScreen(), new IcspService(), shell);
            shell.Show();
        }
    }
}