using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using App5.ViewModels;

namespace App5.Commands
{
    public class BuyBookCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        BookViewModel viewModel;

        public BuyBookCommand(BookViewModel vm)
        {
            viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(CanExecute(parameter))
            {
               // viewModel.Buy();
            }
        }
    }
}
