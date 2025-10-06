using System.Windows;
using CarDealer.Core.Abstractions;
using CarDealer.WPF.VMs;

namespace CarDealer.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AllCarsFrame : Window
    {
        public AllCarsFrame()
        {
            InitializeComponent();
            DataContext = new AllCarsFrameVM();
        }
    }
}