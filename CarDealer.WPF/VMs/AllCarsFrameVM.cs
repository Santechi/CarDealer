using CarDealer.App.Services;
using CarDealer.Core.Abstractions;
using CarDealer.Core.Models;
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
            //Cars = cars.Select(x => new CarVM(x));
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
