namespace CarDealer.Core.Models.Cars
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int State { get; set; }

        public Country(int id, string name, int state)
        {
            Id = id;
            Name = name;
            State = state;
        }

        public static Country Create(int id, string name, int state)
        {
            var country = new Country(id, name, state);

            return country;
        }
    }
}
