using MobileCompany.Models;
using MobileCompany.ViewModels.ViewModels;
using System.Windows;

namespace MobileCompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new AbonentViewModel();
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
        
            // Выполните поиск с использованием введенного номера абонента
            // Здесь можно написать логику поиска по введенному номеру

            NumberSearchPopup.IsOpen = true; // Закрытие попапа после выполнения поиска
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {

            string searchNumber = txtSearchNumber.Text;

            NumberSearchPopup.IsOpen = false; // Закрытие попапа после выполнения поиска

        }
    }
}