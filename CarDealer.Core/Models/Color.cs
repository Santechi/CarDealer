namespace CarDealer.Core.Models
{
    public class Color
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int State { get; set; }

        public Color(int id, string name, int state)
        {
            Id = id;
            Name = name;
            State = state;
        }

        public static Color Create(int id, string name, int state)
        {
            var color = new Color(id, name, state);

            return color;
        }
    }
}
