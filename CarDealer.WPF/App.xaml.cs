using CarDealer.App.Services;
using CarDealer.Core.Abstractions;
using CarDealer.DataAccess.Repos;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.WPF.Services;
using CarDealer.WPF.Views;
using CarDealer.WPF.VMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace CarDealer.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration? Configuration { get; private set; }
        public static ServiceProvider? ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();

            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            services.AddDbContext<CarDealerDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString(nameof(CarDealerDbContext))));

            services.AddSingleton<IFrameService, FrameService>();

            services.AddTransient<ICarRepo, CarRepo>();
            services.AddTransient<ICarService, CarService>();

            services.AddTransient<CarDealerVM>();
            services.AddTransient<CarDealerMain>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<CarDealerMain>();
            mainWindow.Show();
        }
    }
}
