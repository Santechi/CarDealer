using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Abstractions.Sales;
using CarDealer.Core.Models.Sales;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CarDealer.WPF.VMs
{
    public class AllSalesFrameVM : BaseVM
    {
        #region Commands

        public ICommand AddSaleCmd { get; set; }
        public ICommand DeleteSaleCmd { get; set; }

        #endregion

        private readonly ICarService carService;
        private readonly ISaleService saleService;
        private readonly IEmployeeService employeeService;

        private CarVM selectedCarVM;
        public CarVM SelectedCarVM 
        {
            get => selectedCarVM;
            set
            {
                selectedCarVM = value;
                OnPropertyChanged(nameof(SelectedCarVM));
                OnPropertyChanged(nameof(CanCreateSale));
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee 
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                OnPropertyChanged(nameof(CanCreateSale));
            }
        }

        private ObservableCollection<Sale> sales;
        public ObservableCollection<Sale> Sales
        {
            get => sales;
            set
            {
                sales = value;
                OnPropertyChanged(nameof(Sales));
            }
        }

        private Sale selectedSale;
        public Sale SelectedSale
        {
            get => selectedSale;
            set
            {
                selectedSale = value;
                CanDeleteSale = selectedSale != null ? true : false;

                OnPropertyChanged(nameof(SelectedSale));
            }
        }

        public bool CanCreateSale => SelectedCarVM != null && SelectedEmployee != null;

        private bool canDeleteSale;
        public bool CanDeleteSale
        {
            get => canDeleteSale;
            set
            {
                canDeleteSale = value;
                OnPropertyChanged(nameof(CanDeleteSale));
            }
        }

        private List<CarVM> carVMs;
        public List<CarVM> CarVMs
        {
            get => carVMs;
            set
            {
                carVMs = value;
                OnPropertyChanged(nameof(CarVMs));
            }
        }

        private List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public void SetupCommands()
        {
            AddSaleCmd = new BaseCommand(x => AddSale(), x => CanCreateSale);
            DeleteSaleCmd = new BaseCommand(x => DeleteSale(SelectedSale), x => CanDeleteSale);
        }

        public AllSalesFrameVM(IServiceProvider serviceProvider)
        {
            SetupCommands();

            carService = serviceProvider.GetRequiredService<ICarService>();
            saleService = serviceProvider.GetRequiredService<ISaleService>();
            employeeService = serviceProvider.GetRequiredService<IEmployeeService>();

            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            await GetSales();
            await GetCars();
            await GetEmployees();
        }

        public async Task GetSales()
        {
            Sales = new ObservableCollection<Sale>(await saleService.GetAllSales());
        }

        public async Task GetCars()
        {
            var cars = await carService.GetAllCars();
            CarVMs = cars.Select(x => new CarVM(x)).ToList();
        }

        public async Task GetEmployees()
        {
            Employees = await employeeService.GetAllEmployees();
        }

        public async Task AddSale()
        {
            var sale = Sale.Create(0, SelectedCarVM.Parent.Id, DateOnly.FromDateTime(DateTime.Now), SelectedEmployee.Id, 0, SelectedCarVM.Parent, SelectedEmployee);

            var createdSaleId = await saleService.CreateSale(sale);

            if (createdSaleId > 0)
            {
                sale.Id = createdSaleId;
                Sales.Add(sale);
                OnPropertyChanged(nameof(Sales));

                MessageBox.Show("Продажа успешно добавлена!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public async Task DeleteSale(Sale sale)
        {
            var deletedSaleId = await saleService.DeleteSale(sale.Id);

            if (deletedSaleId > 0)
            {
                Sales.Remove(sale);
                OnPropertyChanged(nameof(Sales));

                MessageBox.Show("Продажа успешно удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
