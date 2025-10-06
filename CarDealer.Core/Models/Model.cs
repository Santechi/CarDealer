namespace CarDealer.Core.Models
{
    public class Model
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public Brand? Brand { get; set; }

        public string Name { get; set; }

        public int State { get; set; }

        public Model(int id, int brandId, string name, int state)
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            State = state;
        }

        public static Model Create(int id, int brandId, string name, int state, Brand? brand = null)
        {
            var model = new Model(id, brandId, name, state)
            {
                Brand = brand,
            };

            return model;
        }
    }
}
