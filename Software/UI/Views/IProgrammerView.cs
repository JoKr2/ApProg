using ApProg.Utilities;

namespace ApProg.UI.Views
{
    /// <summary>
    /// Interface to Programmer view 
    /// </summary>
    public interface IProgrammerView
    {
        string Document { get; set; }
        IProgrammerViewObserver Presenter { set; }
        void InformUser(string message);
        bool AskUserForConfiguration(ComPortParams port);
    }

    /// <summary>
    /// Enables the screen to notify observer about user actions.
    /// </summary>
    public interface IProgrammerViewObserver
    {
        bool ConnectSelected();
        void DisconnectSelected();

        void ReadDevIdSelected();
        void ReadAppIdSelected();
        void EraseDeviceSelected();
        void ReadFlashSelected();
        void WriteFlashSelected(string filename);
    }
}
