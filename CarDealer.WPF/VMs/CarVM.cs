using CarDealer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.WPF.VMs
{
    public class CarVM
    {
        public int Id { get; set; }

        public int ComplectId { get; set; }

        public int ColorId { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int State { get; set; }

        public CarVM(Car car)
        {
            Id = car.Id;
            ComplectId = car.ComplectId;
            ColorId = car.ColorId;
            Year = car.Year;
            Price = car.Price;
            State = car.State;
        }
    }
}