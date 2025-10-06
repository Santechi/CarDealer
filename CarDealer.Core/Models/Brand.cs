namespace CarDealer.Core.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int State { get; set; }

        public Brand(int id, string name, int countryId, int state)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
            State = state;
        }

        public static Brand Create(int id, string name, int countryId, int state, Country? country = null)
        {
            var model = new Brand(id, name, countryId, state)
            {
                Country = country,
            };

            return model;
        }
    }
}
