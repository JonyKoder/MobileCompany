using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileCompany.BL.Interfaces;
using MobileCompany.Models;
using MobileCompany.ViewModels.ViewModels;

namespace MobileCompany.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {

        private readonly AbonentViewModel _viewModel;
        private readonly IMobileCompanyService _mobileCompanyService;
        public SearchCommand(AbonentViewModel viewModel, IMobileCompanyService mobileCompanyService)
        {
            _viewModel = viewModel;
            this._mobileCompanyService = mobileCompanyService;
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
                _viewModel.Abonents = _mobileCompanyService.GetAllAbonents();
                _viewModel.Abonents = _mobileCompanyService.GetAbonentByLastName(searchLastName);
            }
        }
    }
}
