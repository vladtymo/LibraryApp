using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Commands
{
    internal sealed class DelegateCommand : Command
    {
        private static readonly Func<object, bool> defaultCanExecuteMethod = (obj) => true;

        private readonly Func<object, bool> canExecuteMethod;
        private readonly Action<object> executeMethod;

        public DelegateCommand(Action<object> executeMethod) :
            this(executeMethod, defaultCanExecuteMethod)
        {
        }

        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.canExecuteMethod = canExecuteMethod;
            this.executeMethod = executeMethod;
        }

        protected override bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        protected override void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
