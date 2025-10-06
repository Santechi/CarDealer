namespace CarDealer.DataAccess.Entities.Cars
{
    public class CarEntity
    {
        public int Id { get; set; }

        public int ComplectId { get; set; }

        public ComplectEntity? Complect { get; set; }

        public int ColorId { get; set; }

        public ColorEntity? Color { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int State { get; set; }
    }
}
