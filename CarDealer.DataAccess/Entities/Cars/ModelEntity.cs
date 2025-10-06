namespace CarDealer.DataAccess.Entities.Cars
{
    public class ModelEntity
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public BrandEntity? Brand { get; set; }

        public List<ComplectEntity>? Complects { get; set; }

        public string Name { get; set; }

        public int State { get; set; }
    }
}
