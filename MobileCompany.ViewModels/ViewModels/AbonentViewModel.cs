using MobileCompany.Models;
using MobileCompany.Models.Models;
using MobileCompany.ViewModels.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace MobileCompany.ViewModels.ViewModels
{
    public class AbonentViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _context;

        public ICommand Search { get; set; }
        public ICommand ResetFilter { get; set; }

        public AbonentViewModel()
        {
            _context = new AppDbContext();  // Создание объекта контекста данных
            Search = new SearchCommand(this, _context);
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

        private List<Abonent> _abonents;
        public List<Abonent> Abonents
        {
            get
            {
                if (_abonents == null)
                {
                    _abonents = _context.Abonents.ToList();  // Получение списка абонентов из контекста
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
