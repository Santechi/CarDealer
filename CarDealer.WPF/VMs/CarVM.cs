using CarDealer.Core.Models.Cars;

namespace CarDealer.WPF.VMs
{
    public class CarVM
    {
        public string Name { get; set; }

        public Car Parent { get; set; }

        public CarVM(Car car)
        {
            Name = GetFullCarName(car);
            Parent = car;
        }

        private string GetFullCarName(Car car)
        {
            return $"{car.Complect?.Model?.Brand?.Name} {car.Complect?.Model?.Name} {car.Complect?.Name} {car.Color?.Name} {car.Year} {car.Price}";
        }
    }
}
