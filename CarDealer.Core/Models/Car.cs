using System.Numerics;

namespace CarDealer.Core.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int ComplectId { get; set; }

        public virtual Complect? Complect { get; set; }

        public int ColorId { get; set; }

        public virtual Color? Color { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int State { get; set; }

        public Car()
        {
        }

        public Car(int id, int complectId, int colorId, int year, decimal price, int state)
        {
            Id = id;
            ComplectId = complectId;
            ColorId = colorId;
            Year = year;
            Price = price;
            State = state;
        }

        public static Car Create(int id, int complectId, int colorId, int year, decimal price, int state, Complect? complect = null, Color? color = null)
        {
            var car = new Car(id, complectId, colorId, year, price, state)
            {
                Complect = complect,
                Color = color
            };

            return car;
        }
    }
}
