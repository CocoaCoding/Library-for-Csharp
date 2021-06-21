using System;
using System.Windows.Input;

namespace Hinzberg.WPF_Commands
{
    // Class for WPF/XAML Command Bindings
    // but without the CanExecute property.
    // The Action can always be executed and that will never change
    // If CanExecute will change use DelegateCommand instead.

    public class DelegateCommandSimple : ICommand
    {

        private readonly Action _action;

        public DelegateCommandSimple(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            try
            {
                _action();
            }
            catch (Exception ex)
            {
                // Logger.GetInstance.DebugLogger($"[{nameof(DelegateCommand)}][{nameof(Execute)}]" + ex);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

    }
}
