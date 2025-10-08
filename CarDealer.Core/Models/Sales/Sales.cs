using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Models.Sales
{
    public class Sale
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public virtual Car? Car { get; set; }

        public DateOnly SaleDate { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

        public int State { get; set; }

        public Sale()
        {
        }

        public Sale(int id, int carId, DateOnly saleDate, int employeeId, int state)
        {
            Id = id;
            CarId = carId;
            SaleDate = saleDate;
            EmployeeId = employeeId;
            State = state;
        }

        public static Sale Create(int id, int carId, DateOnly saleDate, int employeeId, int state, Car? car = null, Employee? employee = null)
        {
            var sale = new Sale(id, carId, saleDate, employeeId, state)
            {
                Car = car,
                Employee = employee
            };

            return sale;
        }
    }
}
