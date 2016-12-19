using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Faellesspinsning
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action execute) : this(execute, null)
        {

        }
        private Action methodToExecute = null;
        private Func<bool> methodToDecectCanExecute = null;

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDecectCanExecute = methodToDetectCanExecute;
        }
        public void Execute(object parameter)
        {
            this.methodToExecute();
        }
        public bool CanExecute(object parameter)
        {
            if (this.methodToDecectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDecectCanExecute();
            }
        }
        public event EventHandler CanExecuteChanged;
    }
}
