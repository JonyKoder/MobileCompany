using MobileCompany.Models;
using MobileCompany.Models.Models;
using MobileCompany.ViewModels.Commands;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MobileCompany.BL.Interfaces;
using MobileCompany.ViewModels.Dto;

namespace MobileCompany.ViewModels.ViewModels
{
    public class AbonentViewModel : INotifyPropertyChanged
    {
        private readonly IMobileCompanyService _mobileCompanyService;

        public ICommand Search { get; set; }
        public ICommand ExportCSV { get; set; }
        public ICommand ResetFilter { get; set; }

        public AbonentViewModel(IMobileCompanyService mobileCompanyService)
        {
            _mobileCompanyService = mobileCompanyService;
            Search = new SearchCommand(this, _mobileCompanyService);
            ExportCSV = new ExportCommand(this);
        }

       
        private string _searchLastName;
        public string SearchLastName
        {
            get { return _searchLastName; }
            set
            {
                _searchLastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchLastName)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
       
        private List<AbonentDto> _abonents;
        public List<AbonentDto> Abonents
        {
            get
            {
                if (_abonents == null)
                {
                    _abonents = _mobileCompanyService.GetAllAbonents();  // Получение списка абонентов из контекста
                }
                return _abonents;
            }
            set
            {
                _abonents = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Abonents)));
            }
        }

    }
}
