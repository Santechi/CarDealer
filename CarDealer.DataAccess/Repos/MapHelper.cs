using CarDealer.Core.Models.Cars;
using CarDealer.Core.Models.Sales;
using CarDealer.DataAccess.Entities.Cars;
using CarDealer.DataAccess.Entities.Sales;

namespace CarDealer.DataAccess.Repos
{
    public static class MapHelper
    {
        public static Country? MapCountry(CountryEntity? entity)
        {
            if (entity == null)
                return null;

            return Country.Create(
                entity.Id,
                entity.Name,
                entity.State
            );
        }

        public static Brand? MapBrand(BrandEntity? entity)
        {
            if (entity == null)
                return null;

            return Brand.Create(
                entity.Id,
                entity.Name,
                entity.CountryId,
                entity.State,
                MapCountry(entity.Country)
            );
        }

        public static Model? MapModel(ModelEntity? entity)
        {
            if (entity == null)
                return null;

            return Model.Create(
                entity.Id,
                entity.BrandId,
                entity.Name,
                entity.State,
                MapBrand(entity.Brand)
            );
        }

        public static Complect? MapComplect(ComplectEntity? entity)
        {
            if (entity == null)
                return null;

            return Complect.Create(
                entity.Id,
                entity.ModelId,
                entity.Name,
                entity.Engine,
                entity.Transmission,
                entity.State,
                MapModel(entity.Model)
            );
        }

        public static Color? MapColor(ColorEntity? entity)
        {
            if (entity == null)
                return null;

            return Color.Create(
                entity.Id,
                entity.Name,
                entity.State
            );
        }

        public static Car? MapCar(CarEntity? entity)
        {
            if (entity == null)
                return null;

            return Car.Create(
                entity.Id,
                entity.ComplectId,
                entity.ColorId,
                entity.Year,
                entity.Price,
                entity.State,
                MapComplect(entity.Complect),
                MapColor(entity.Color)
            );
        }

        public static Employee? MapEmployee(EmployeeEntity? entity)
        {
            if (entity == null)
                return null;

            return Employee.Create(
                entity.Id,
                entity.Fio,
                entity.Email,
                entity.Phone,
                entity.State
            );
        }
    }
}
