using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Windows;
using Autofac;
using AutoMapper;
using MobileCompany.BL.Interfaces;
using MobileCompany.BL.Services;
using MobileCompany.Models;
using Npgsql;

namespace MobileCompany
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ConfigureAutoMapper();
            // Далее вызов главного окна вашего приложения
        }
        private void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                // Добавьте другие профили маппинга здесь, если необходимо
            });

            // Запуск конфигурации AutoMapper
            IMapper mapper = config.CreateMapper();
            // Добавьте маппер в сервисы или используйте его напрямую
            // Например: services.AddSingleton<IMapper>(mapper);
        }
        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Регистрация зависимостей 
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); // Замените на свой профиль AutoMapper
            }).CreateMapper()).As<IMapper>();
            builder.RegisterType<MobileCompanyService>().As<IMobileCompanyService>() .WithParameter("connection", new NpgsqlConnection("Host=localhost;Port=5432;Database=MobileCompanyDb;Username=root;Password=myPassword"));
          
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return ((App)Application.Current)._container.Resolve<T>();
        }
    }

}
