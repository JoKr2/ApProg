using System;
using System.Windows.Input;

namespace ApProg.UserInterface.Shell
{
    public class UiCommand : ICommand
    {
        private readonly Action<object> myAction;

        public UiCommand(Action<object> action)
        {
            myAction = action;
        }

        public void Execute(object parameter)
        {
            myAction(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}