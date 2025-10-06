namespace CarDealer.DataAccess.Entities.Cars
{
    public class BrandEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public CountryEntity Country { get; set; }

        public int State { get; set; }
    }
}
