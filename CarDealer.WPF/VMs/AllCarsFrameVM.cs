using CarDealer.Core.Models.Cars;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarDealer.WPF.VMs
{
    public class AllCarsFrameVM : BaseVM
    {
        #region Commands

        public ICommand LoadAllCarsCmd { get; set; }

        #endregion

        private List<Car> cars;
        public List<Car> Cars 
        { 
            get => cars;
            set 
            {
                cars = value;
                OnPropertyChanged("Cars");
            }
        }

        public AllCarsFrameVM()
        {
        }

        public AllCarsFrameVM(List<Car> cars)
        {
            SetupCommands();

            Cars = cars;
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
