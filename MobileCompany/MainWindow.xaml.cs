using System.Text;
using MobileCompany.Models;
using MobileCompany.ViewModels.ViewModels;
using System.Windows;
using MobileCompany.BL.Interfaces;

namespace MobileCompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMobileCompanyService _mobileCompanyService;
        public MainWindow()
        {
            _mobileCompanyService = App.Resolve<IMobileCompanyService>();
            DataContext = new AbonentViewModel(_mobileCompanyService);
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            InitializeComponent();
        }
       
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            NumberSearchPopup.IsOpen = true; // Закрытие попапа после выполнения поиска
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {

            string searchNumber = txtSearchNumber.Text;

            NumberSearchPopup.IsOpen = false; // Закрытие попапа после выполнения поиска

        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Файл CSV сохранён в мои документы";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }
    }
}