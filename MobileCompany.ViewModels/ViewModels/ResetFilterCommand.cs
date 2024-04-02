using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileCompany.ViewModels.ViewModels
{
    public class ResetFilterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly AbonentViewModel _viewModel;
        public ResetFilterCommand(AbonentViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
          
        }
    }
}
