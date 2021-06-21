using System;
using System.Windows.Input;

namespace Hinzberg.WPF_Commands
{
    // Class for WPF/XAML Command Bindings

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<object> _executeAction; // object is CommandParameter in Xaml, if used
        private readonly Predicate<object> _canExecute; // A Predicate is  functionpointer that will return a bool

        /// <summary>
        /// 
        /// </summary>
        /// <param name="executeAction">The Action, can be an anonym delegate sein</param>
        /// <param name="canExecute">Predicate, determines if the action can be called </param>
        public DelegateCommand(Action<object> executeAction, Predicate<object> canExecute)
        {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
