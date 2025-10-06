using CarDealer.Core.Abstractions.Cars;
using CarDealer.WPF.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CarDealer.WPF.VMs
{
    public class CarDealerVM : BaseVM
    {
        #region Commands

        public ICommand LoadAllCarsCmd { get; set; }

        #endregion

        private readonly IFrameService frameService;
        private readonly ICarService carService;

        public CarDealerVM(IServiceProvider serviceProvider)
        {
            SetupCommands();

            frameService = serviceProvider.GetRequiredService<IFrameService>();
            carService = serviceProvider.GetRequiredService<ICarService>();
        }

        public void SetupCommands()
        {
            LoadAllCarsCmd = new BaseCommand(x => LoadAllCars());
        }

        public async Task LoadAllCars()
        {
            var cars = await carService.GetAllCars();

            if (cars is null)
                throw new ApplicationException("Couldn't get any cars from db");

            frameService.ShowWindow(new AllCarsFrameVM(cars));
        }
    }
}
