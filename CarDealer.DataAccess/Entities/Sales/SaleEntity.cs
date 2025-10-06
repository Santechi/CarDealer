using CarDealer.DataAccess.Entities.Cars;

namespace CarDealer.DataAccess.Entities.Sales
{
    public class SaleEntity
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public CarEntity? Car { get; set; }

        public DateTime SaleDate { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeEntity? Employee { get; set; }

        public int State { get; set; }
    }
}
