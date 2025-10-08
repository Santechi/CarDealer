using CarDealer.Core.Abstractions.Sales;
using CarDealer.Core.Models.Sales;
using CarDealer.WPF.Services;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows.Input;

namespace CarDealer.WPF.VMs
{
    public class CarDealerVM : BaseVM
    {
        #region Commands

        public ICommand LoadAllCarsCmd { get; set; }
        public ICommand LoadAllSalesCmd { get; set; }
        public ICommand CalcAllSalesCmd { get; set; }
        public ICommand ExcelExportCmd { get; set; }

        #endregion

        private readonly IServiceProvider serviceProvider;
        private readonly IFrameService frameService;
        private readonly ISaleService saleService;

        public int SelectedYear { get; set; }

        int startYear = 2000;
        int endYear = DateTime.Now.Year + 5;

        public IEnumerable<int> Years { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();

        private List<YearSaleVM> carSales;
        public List<YearSaleVM> CarSales
        { 
            get => carSales;
            set
            {
                carSales = value;
                OnPropertyChanged(nameof(CarSales));
            }
        }

        public CarDealerVM(IServiceProvider serviceProvider)
        {
            SetupCommands();

            Years = Enumerable.Range(startYear, endYear - startYear + 1);

            this.serviceProvider = serviceProvider;

            frameService = serviceProvider.GetRequiredService<IFrameService>();
            saleService = serviceProvider.GetRequiredService<ISaleService>();
        }

        public void SetupCommands()
        {
            LoadAllCarsCmd = new BaseCommand(x => LoadAllCars());
            LoadAllSalesCmd = new BaseCommand(x => LoadAllSales());
            CalcAllSalesCmd = new BaseCommand(x => CalcAllSales());
            ExcelExportCmd = new BaseCommand(x => ExportExcel());
        }

        public async Task LoadAllCars()
        {
            frameService.ShowWindow(new AllCarsFrameVM(serviceProvider));
        }

        public async Task LoadAllSales()
        {
            frameService.ShowWindow(new AllSalesFrameVM(serviceProvider));
        }

        public async Task CalcAllSales()
        {
            Sales = await saleService.GetAllSales();

            if (SelectedYear > 0)
                CarSales = Sales.Where(s => s.SaleDate.Year == SelectedYear).GroupBy(s => s.Car?.Complect?.Model?.Id).Select(g => new YearSaleVM(g.ToList())).ToList();
        }

        public async Task ExportExcel()
        {
            var saveDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "Продажи.csv"
            };

            if (saveDialog.ShowDialog() == true)
            {
                ExportExcel(CarSales, saveDialog.FileName);
            }
        }

        private void ExportExcel<T>(IEnumerable<T> items, string filePath)
        {
            var properties = typeof(T).GetProperties();

            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(string.Join(";", properties.Select(p => p.Name)));

                foreach (var item in items)
                {
                    var values = properties.Select(p => p.GetValue(item, null)?.ToString()?.Replace(";", ",") ?? "");
                    writer.WriteLine(string.Join(";", values));
                }
            }
        }
    }
}
