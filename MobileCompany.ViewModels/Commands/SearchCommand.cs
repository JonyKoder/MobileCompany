using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileCompany.ViewModels.ViewModels;

namespace MobileCompany.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {
        private readonly AbonentViewModel _viewModel;

        public SearchCommand(AbonentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string searchLastName = _viewModel.SearchLastName;
            if (!string.IsNullOrEmpty(searchLastName))
            {
                _viewModel.Abonents = _viewModel.Abonents.Where(a => a.LastName.ToLower().Trim().Contains(searchLastName.ToLower().Trim())).ToList();
            }
        }
    }
}
