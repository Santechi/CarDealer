using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.WPF.Services
{
    public interface IFrameService
    {
        void ShowWindow<TViewModel>(TViewModel viewModel) where TViewModel : class;
    }
}
