namespace CarDealer.DataAccess.Entities
{
    public class ComplectEntity
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public ModelEntity? Model { get; set; }

        public string Name { get; set; }

        public string Engine { get; set; }

        public string Transmission { get; set; }

        public int State { get; set; }
    }
}