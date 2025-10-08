using CarDealer.Core.Models.Sales;
using System.Windows.Input;

namespace CarDealer.WPF.VMs
{
    public class AllSalesFrameVM : BaseVM
    {
        #region Commands

        public ICommand LoadAllCarsCmd { get; set; }

        #endregion

        private List<Sale> sales;
        public List<Sale> Sales 
        { 
            get => sales;
            set 
            {
                sales = value;
                OnPropertyChanged("Sales");
            }
        }

        public AllSalesFrameVM()
        {
        }

        public AllSalesFrameVM(List<Sale> sales)
        {
            SetupCommands();

            Sales = sales;
        }

        public void SetupCommands()
        {
            LoadAllCarsCmd = new BaseCommand(x => LoadAllCars());
        }

        public async Task LoadAllCars()
        {
            //
        }
    }
}
