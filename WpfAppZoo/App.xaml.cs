using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfAppZoo.Stores;
using WpfAppZoo.ViewModels;
using WpfAppZoo.Views;
using Zoo.Domain.Commands;
using Zoo.Domain.Queries;
using Zoo.EntityFramework;
using Zoo.EntityFramework.Commands;
using Zoo.EntityFramework.Queries;
using WpfAppZoo.HostBuilders;


namespace WpfAppZoo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IGetAllAnimalsQuery, GetAllAnimalsQuery>();
                    services.AddSingleton<ICreateAnimalCommand, CreateAnimalCommand>();
                    services.AddSingleton<IUpdateAnimalCommand, UpdateAnimalCommand>();
                    services.AddSingleton<IDeleteAnimalCommand, DeleteAnimalCommand>();

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<AnimalsStore>();
                    services.AddSingleton<SelectedAnimalStore>();

                    services.AddTransient<AnimalsViewModel>(CreateAnimalsViewModel);
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();           

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            AnimalsDbContextFactory animalsDbContextFactory = _host.Services.GetRequiredService<AnimalsDbContextFactory>();
            using (AnimalsDbContext context = animalsDbContextFactory.Create()) 
            { 
                context.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
        private AnimalsViewModel CreateAnimalsViewModel(IServiceProvider services)
        {
            return AnimalsViewModel.LoadViewModel(
                services.GetRequiredService<AnimalsStore>(),
                services.GetRequiredService<SelectedAnimalStore>(),
                services.GetRequiredService<ModalNavigationStore>());
                
        }
    }

}
