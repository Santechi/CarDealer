using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CarDealer.WPF.VMs
{
    public class AllCarsFrameVM : BaseVM
    {
        #region Commands

        public ICommand AddCarCmd { get; set; }
        public ICommand DeleteCarCmd { get; set; }

        #endregion

        private readonly ICarService carService;
        private readonly IBrandService brandService;
        private readonly IModelService modelService;
        private readonly IComplectService complectService;
        private readonly IColorService colorService;

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(CanCreateCar));
            }
        }

        public bool IsComplectEnabled { get; set; } = false;

        public bool CanCreateCar => SelectedComplect != null 
                                 && SelectedBrand != null
                                 && SelectedYear > 0
                                 && SelectedComplect != null
                                 && SelectedColor != null;

        private bool canDeleteCar;
        public bool CanDeleteCar 
        { 
            get => canDeleteCar;
            set 
            {
                canDeleteCar = value;
                OnPropertyChanged(nameof(CanDeleteCar));
            } 
        }

        private int selectedYear;
        public int SelectedYear
        { 
            get => selectedYear;
            set
            {
                selectedYear = value;
                OnPropertyChanged(nameof(CanCreateCar));
            }
        }

        int startYear = 2000;
        int endYear = DateTime.Now.Year + 5;

        public IEnumerable<int> Years { get; set; }

        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get => selectedBrand;
            set
            {
                selectedBrand = value;
                OnPropertyChanged(nameof(SelectedBrand));
                OnPropertyChanged(nameof(CanCreateCar));

                ModelsView?.Refresh();
                ComplectsView?.Refresh();
            }
        }

        private Model selectedModel;
        public Model SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;

                if (selectedModel != null)
                    IsComplectEnabled = true;
                else
                {
                    IsComplectEnabled = false;
                    SelectedComplect = null;
                }

                ComplectsView?.Refresh();

                OnPropertyChanged(nameof(SelectedModel));
                OnPropertyChanged(nameof(SelectedComplect));
                OnPropertyChanged(nameof(IsComplectEnabled));
                OnPropertyChanged(nameof(CanCreateCar));
            }
        }

        private Complect selectedComplect;
        public Complect SelectedComplect
        {
            get => selectedComplect;
            set
            {
                selectedComplect = value;
                OnPropertyChanged(nameof(SelectedComplect));
                OnPropertyChanged(nameof(CanCreateCar));
            }
        }

        private Color selectedColor;
        public Color SelectedColor
        {
            get => selectedColor;
            set
            {
                selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
                OnPropertyChanged(nameof(CanCreateCar));
            }
        }

        private ObservableCollection<Car> cars;
        public ObservableCollection<Car> Cars 
        { 
            get => cars;
            set 
            {
                cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        private List<Brand> brands;
        public List<Brand> Brands
        {
            get => brands;
            set
            {
                brands = value;
                OnPropertyChanged(nameof(Brands));
            }
        }

        private ICollectionView brandsView;
        public ICollectionView BrandsView
        {
            get => brandsView;
            set
            {
                brandsView = value;
                OnPropertyChanged(nameof(BrandsView));
            }
        }

        private List<Model> models;
        public List<Model> Models
        {
            get => models;
            set
            {
                models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        private ICollectionView modelsView;
        public ICollectionView ModelsView
        {
            get => modelsView;
            set
            {
                modelsView = value;
                OnPropertyChanged(nameof(ModelsView));
            }
        }

        private List<Complect> complects;
        public List<Complect> Complects
        {
            get => complects;
            set
            {
                complects = value;
                OnPropertyChanged(nameof(Complects));
            }
        }

        private ICollectionView complectsView;
        public ICollectionView ComplectsView
        {
            get => complectsView;
            set
            {
                complectsView = value;
                OnPropertyChanged(nameof(ComplectsView));
            }
        }

        private List<Color> colors;
        public List<Color> Colors
        {
            get => colors;
            set
            {
                colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }

        private Car selectedCar;

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                CanDeleteCar = selectedCar != null ? true : false;

                OnPropertyChanged(nameof(SelectedCar));
                OnPropertyChanged(nameof(CanCreateCar));
            }
        }

        public void SetupCommands()
        {
            AddCarCmd = new BaseCommand(x => AddCar(), x => CanCreateCar);
            DeleteCarCmd = new BaseCommand(x => DeleteCar(SelectedCar), x => CanDeleteCar);
        }

        public AllCarsFrameVM(IServiceProvider serviceProvider)
        {
            SetupCommands();

            carService = serviceProvider.GetRequiredService<ICarService>();
            brandService = serviceProvider.GetRequiredService<IBrandService>();
            modelService = serviceProvider.GetRequiredService<IModelService>();
            complectService = serviceProvider.GetRequiredService<IComplectService>();
            colorService = serviceProvider.GetRequiredService<IColorService>();

            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            await GetCars();
            await SetupAllCarParams();
        }

        public async Task GetCars()
        {
            Cars = new ObservableCollection<Car>(await carService.GetAllCars());
        }

        public async Task SetupAllCarParams()
        {
            Years = Enumerable.Range(startYear, endYear - startYear + 1);
            OnPropertyChanged(nameof(Years));

            Brands = await brandService.GetAllBrands();
            Colors = await colorService.GetAllColors();

            Models = await modelService.GetAllModels();
            ModelsView = CollectionViewSource.GetDefaultView(Models);
            ModelsView.Filter = FilterModelsByBrand;

            Complects = await complectService.GetAllComplects();
            ComplectsView = CollectionViewSource.GetDefaultView(Complects);
            ComplectsView.Filter = FilterComplectByModel;
        }

        private bool FilterModelsByBrand(object obj)
        {
            if (obj is not Model model)
                return false;
            if (SelectedBrand == null)
                return true;

            return model.BrandId == SelectedBrand.Id;
        }

        private bool FilterComplectByModel(object obj)
        {
            if (obj is not Complect complect)
                return false;

            if (SelectedModel == null)
                return true;

            return complect.ModelId == SelectedModel.Id;
        }

        public async Task AddCar()
        {
            var car = Car.Create(0, SelectedComplect.Id, SelectedColor.Id, SelectedYear, Price, 0, SelectedComplect, SelectedColor);

            var createdCarId = await carService.CreateCar(car);

            if (createdCarId > 0)
            {
                car.Id = createdCarId;
                Cars.Add(car);
                OnPropertyChanged(nameof(Cars));

                MessageBox.Show("Автомобиль успешно добавлен!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public async Task DeleteCar(Car car)
        {
            var deletedCarId = await carService.DeleteCar(car.Id);

            if (deletedCarId > 0)
            {
                Cars.Remove(car);
                OnPropertyChanged(nameof(Cars));

                MessageBox.Show("Автомобиль успешно удалён!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
