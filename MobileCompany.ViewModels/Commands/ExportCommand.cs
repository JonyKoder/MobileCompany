using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Uwp.Notifications;
using MobileCompany.BL.Interfaces;
using MobileCompany.Models;
using MobileCompany.ViewModels.ViewModels;

namespace MobileCompany.ViewModels.Commands
{
    public class ExportCommand : ICommand
    {

        private readonly AbonentViewModel _viewModel;
        public ExportCommand(AbonentViewModel viewModel)
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
            try
            {
                string csvContent = GenerateCsvContent();
                SaveCsvFile(csvContent);
            }
            catch (Exception ex)
            {
                // Обработка ошибок
            }
        }

        private string GenerateCsvContent()
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Улица, Количество абонентов");

            foreach (var subscriber in _viewModel.Abonents)
            {
                string street = subscriber.Address;
                int numberOfSubscribers = 1;

                csvContent.AppendLine($"{street}, {numberOfSubscribers}");
            }

            return csvContent.ToString();
        }
        private void SaveCsvFile(string content)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"report_{timestamp}.csv";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            File.WriteAllText(filePath, content, Encoding.UTF8);
            
        }




    }
}
