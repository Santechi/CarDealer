using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.App.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepo colorRepo;

        public ColorService(IColorRepo colorRepo)
        {
            this.colorRepo = colorRepo;
        }

        public async Task<List<Color>> GetAllColors()
        {
            return await colorRepo.Get();
        }
    }
}
