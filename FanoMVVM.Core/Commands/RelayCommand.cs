using System;
using System.Windows.Input;

namespace FanoMvvm.Commands
{
    public class RelayCommand<TCommandArgs> : ICommand
    {
        private readonly Action<TCommandArgs> _execute;
        private readonly Func<TCommandArgs, bool> _canExecute;

        public RelayCommand(Action<TCommandArgs> onExecute, Func<TCommandArgs, bool> canExecute)
        {
            this._execute = onExecute;
            this._canExecute = canExecute;
        }

        public RelayCommand(Action<TCommandArgs> onExecute) : this(onExecute, arg => true) { }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute((TCommandArgs)parameter);
        }

        public void Execute(object parameter)
        {
            this._execute((TCommandArgs)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action onExecute, Func<bool> canExecute) : base(o => onExecute(), o => canExecute())
        {

        }

        public RelayCommand(Action onExecute) : base(o => onExecute(), o => true)
        {

        }
    }
}