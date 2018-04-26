using System;
using System.Windows.Input;

namespace Player
{
    public class RelayCommand :  ICommand
    {
        #region private Members

        private Action mAction;
        #endregion

        #region Constructor

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion


        public event EventHandler CanExecuteChanged = (sender,e) => { };

        public bool CanExecute(object parameter)
         {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }

        
    }
}
