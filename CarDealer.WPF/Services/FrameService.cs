using CarDealer.WPF.Views;
using CarDealer.WPF.VMs;
using System.Windows;

namespace CarDealer.WPF.Services
{
    public class FrameService : IFrameService
    {
        public void ShowWindow<TViewModel>(TViewModel viewModel) where TViewModel : class
        {
            Window? window = null;

            if (viewModel is AllCarsFrameVM)
                window = new AllCarsFrame();
            else if (viewModel is AllSalesFrameVM)
                window = new AllSalesFrame();

            if (window != null)
            {
                window.DataContext = viewModel;
                window.ShowDialog();
            }
            else
            {
                throw new ApplicationException("Smth wrong with frames");
            }
        }
    }
}
