using MobileCompany.Models;
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
        private readonly AppDbContext _context;
        public ResetFilterCommand(AbonentViewModel viewModel, AppDbContext context)
        {
            _viewModel = viewModel;
            this._context = context;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Abonents = _context.Abonents.ToList();
        }
    }
}
