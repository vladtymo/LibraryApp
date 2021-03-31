using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.Commands
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

<<<<<<< HEAD
        protected virtual bool CanExecute(object parameter)
=======
        protected virtual bool CanExecute()
>>>>>>> master
        {
            return true;
        }

<<<<<<< HEAD
        protected abstract void Execute(object parameter);
=======
        protected abstract void Execute();
>>>>>>> master

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
<<<<<<< HEAD
            return CanExecute(parameter);
=======
            return CanExecute();
>>>>>>> master
        }

        void ICommand.Execute(object parameter)
        {
<<<<<<< HEAD
            Execute(parameter);
=======
            Execute();
>>>>>>> master
        }
    }
}
