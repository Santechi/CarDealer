using System.Windows;
using CarDealer.Core.Abstractions;
using CarDealer.WPF.VMs;

namespace CarDealer.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CarDealerMain : Window
    {
        public CarDealerMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new CarDealerVM(serviceProvider);
        }
    }
}