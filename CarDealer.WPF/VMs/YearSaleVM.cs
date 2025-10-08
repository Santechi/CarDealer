using CarDealer.Core.Models.Cars;
using CarDealer.Core.Models.Sales;

namespace CarDealer.WPF.VMs
{
    public class YearSaleVM
    {
        public string? Model { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }

        public YearSaleVM(List<Sale> sales)
        {
            if (sales == null || sales.Count == 0)
            {
                Model = "N/A";
                return;
            }

            if (!sales.All(x => x.Car != null))
                throw new ApplicationException("Не во всех продажах есть ссылка на автомобиль");

            var firstCar = sales.First().Car;
            var monthGroups = sales.GroupBy(s => s.SaleDate.Month).ToDictionary(g => g.Key, g => g.Sum(s => s?.Car?.Price ?? 0));

            Model = GetFullModelName(firstCar?.Complect?.Model);
            January = monthGroups.GetValueOrDefault(1);
            February = monthGroups.GetValueOrDefault(2);
            March = monthGroups.GetValueOrDefault(3);
            April = monthGroups.GetValueOrDefault(4);
            May = monthGroups.GetValueOrDefault(5);
            June = monthGroups.GetValueOrDefault(6);
            July = monthGroups.GetValueOrDefault(7);
            August = monthGroups.GetValueOrDefault(8);
            September = monthGroups.GetValueOrDefault(9);
            October = monthGroups.GetValueOrDefault(10);
            November = monthGroups.GetValueOrDefault(11);
            December = monthGroups.GetValueOrDefault(12);
        }

        private string GetFullModelName(Model model)
        {
            if (model == null)
                return "N/A";

            var brandName = model.Brand?.Name;
            var modelName = model.Name;

            return $"{brandName} {modelName}";
        }
    }
}
