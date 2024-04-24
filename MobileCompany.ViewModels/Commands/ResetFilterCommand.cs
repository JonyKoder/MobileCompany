using System.Windows.Input;
using MobileCompany.BL.Interfaces;
using MobileCompany.Models;

namespace MobileCompany.ViewModels.ViewModels
{
    public class ResetFilterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly AbonentViewModel _viewModel;
        private readonly IMobileCompanyService _service;
        public ResetFilterCommand(AbonentViewModel viewModel, IMobileCompanyService service)
        {
            _viewModel = viewModel;
            this._service = service;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Abonents = _service.GetAllAbonents();
        }
    }
}
