using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WorkersDep.Services.DelegateCommand
{
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        private Action<object> execute;
        private Predicate<object> canExecute;


        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;

            if(canExecute == null) canExecute = AlwayesTrue;

            this.canExecute = canExecute;

        }


        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        private bool AlwayesTrue(object parameter) 
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
      
    }
}
