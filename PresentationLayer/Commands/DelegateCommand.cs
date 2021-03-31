using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Commands
{
    internal sealed class DelegateCommand : Command
    {
<<<<<<< HEAD
        private static readonly Func<object, bool> defaultCanExecuteMethod = (obj) => true;

        private readonly Func<object, bool> canExecuteMethod;
        private readonly Action<object> executeMethod;

        public DelegateCommand(Action<object> executeMethod) :
=======
        private static readonly Func<bool> defaultCanExecuteMethod = () => true;

        private readonly Func<bool> canExecuteMethod;
        private readonly Action executeMethod;

        public DelegateCommand(Action executeMethod) :
>>>>>>> master
            this(executeMethod, defaultCanExecuteMethod)
        {
        }

<<<<<<< HEAD
        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
=======
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
>>>>>>> master
        {
            this.canExecuteMethod = canExecuteMethod;
            this.executeMethod = executeMethod;
        }

<<<<<<< HEAD
        protected override bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        protected override void Execute(object parameter)
        {
            executeMethod(parameter);
=======
        protected override bool CanExecute()
        {
            return canExecuteMethod();
        }

        protected override void Execute()
        {
            executeMethod();
>>>>>>> master
        }
    }
}
