namespace CarDealer.Core.Models.Cars
{
    public class Complect
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public Model? Model { get; set; }

        public string Name { get; set; }

        public string Engine { get; set; }

        public string Transmission { get; set; }

        public int State { get; set; }

        public Complect(int id, int modelId, string name, string engine, string transmission, int state)
        {
            Id = id;
            ModelId = modelId;
            Name = name;
            Engine = engine;
            Transmission = transmission;
            State = state;
        }

        public static Complect Create(int id, int modelId, string name, string engine, string transmission, int state, Model? model = null)
        {
            var complect = new Complect(id, modelId, name, engine, transmission, state)
            {
                Model = model,
            };

            return complect;
        }
    }
}
