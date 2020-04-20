using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using Business.Abstract;
using Models;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IAnimalService _animalService;
        private readonly IFoodService _foodService;
        private readonly ITimeService _timeService;

        private ObservableCollection<AnimalModel> _animalModels;
        private ObservableCollection<FoodModel> _foodModels;
        private ObservableCollection<AnimalModel> _hungry;
        private ObservableCollection<FoodModel> _suitableFood;

        private DateTime _currentTime;
        private RelayCommand _feedCommand;
        private RelayCommand _shiftTimeCommand;
        private RelayCommand _updateWindowCommand;

        private AnimalModel _selectedAnimal;

        private RelayCommand _serializeAnimals;
        private RelayCommand _deserializeAnimals;
        
        private RelayCommand _serializeFood;
        private RelayCommand _deserializeFood;
        
        private readonly IOpenCommandAnimal _openAddAnimalWindow;
        private readonly IOpenCommandFood _openCommandFood;
        

        private readonly string _animalPath;
        private readonly string _foodPath;


        public MainWindowViewModel(ITimeService timeService, IAnimalService animalService, IFoodService foodService, IOpenCommandAnimal openCommandAnimal, IOpenCommandFood openCommandFood)
        {
            _timeService = timeService;
            _animalService = animalService;
            _foodService = foodService;
            _currentTime = _timeService.CurrentTime;

            _hungry = new ObservableCollection<AnimalModel>(_animalService.GetHungryAnimals());
            _foodModels = new ObservableCollection<FoodModel>(_foodService.GetAll());
            _animalModels = new ObservableCollection<AnimalModel>(_animalService.GetAllAnimals());

            _openAddAnimalWindow = openCommandAnimal;
            _openCommandFood = openCommandFood;
            
            _foodPath = ConfigurationManager.AppSettings["FoodSerializationPath"];
            _animalPath = ConfigurationManager.AppSettings["AnimalSerializationPath"];
        }

        public int Hours { get; set; }

        public DateTime CurrentTime
        {
            get => _currentTime;
            set
            {
                _currentTime = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AnimalModel> Hungry
        {
            get => _hungry;
            set
            {
                _hungry = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AnimalModel> AnimalModels
        {
            get => _animalModels;
            set
            {
                _animalModels = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FoodModel> FoodModels
        {
            get => _foodModels;
            set
            {
                _foodModels = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FoodModel> SuitableFood
        {
            get => _suitableFood;
            set
            {
                _suitableFood = value;
                OnPropertyChanged();
            }
        }

        public AnimalModel SelectedAnimal
        {
            get => _selectedAnimal;
            set
            {
                _selectedAnimal = value;
                GetSuitableFood();
                OnPropertyChanged();
            }
        }

        public IOpenCommandAnimal OpenAddAnimalWindow => _openAddAnimalWindow;

        public IOpenCommandFood OpenCommandFood => _openCommandFood;
        private void GetSuitableFood()
        {
            var food = _foodService.GetSuitableFoodForAnimal(SelectedAnimal.Id);

            SuitableFood = new ObservableCollection<FoodModel>(food);
        }

        public FoodModel SelectedFoodModel { get; set; }

        public RelayCommand FeedAnimal
        {
            get
            {
                return _feedCommand ??=
                    new RelayCommand(o =>
                    {
                        _animalService.FeedAnimal(SelectedAnimal, SelectedFoodModel);

                        MessageBox.Show($"Покормил {SelectedAnimal.Name}", "Info", MessageBoxButton.OK,
                            MessageBoxImage.Information);


                        SelectedFoodModel = null;
                        SuitableFood = null;
                        UpdateWindow();
                    }, o => SelectedFoodModel != null);
            }
        }
        
        internal void UpdateWindow()
        {
            AnimalModels = new ObservableCollection<AnimalModel>(_animalService.GetAllAnimals());
            Hungry = new ObservableCollection<AnimalModel>(_animalService.GetHungryAnimals());
            FoodModels = new ObservableCollection<FoodModel>(_foodService.GetAll());
            CurrentTime = _timeService.CurrentTime;
        }

        public RelayCommand ShiftTime
        {
            get
            {
                return _shiftTimeCommand ??= new RelayCommand(o =>
                {
                    _timeService.ShiftTime(Hours);
                    UpdateWindow();
                }, o => Hours != 0);
            }
        }
        
        public RelayCommand UpdateWindowCommand
        {
            get
            {
                return _updateWindowCommand ??= new RelayCommand(o =>
                {
                    UpdateWindow();
                });
            }
        }
        
        public RelayCommand SerializeAnimals
        {
            get
            {
                return _serializeAnimals ??= new RelayCommand(o =>
                {
                    _animalService.Serialize(_animalModels as ICollection<AnimalModel>, _animalPath);
                });
            }
        }
        
        public RelayCommand DeserializeAnimals
        {
            get
            {
                return _deserializeAnimals ??= new RelayCommand(o =>
                {
                    var animalsCollection = _animalService.Deserialize(_animalPath);
                    
                    AnimalModels = new ObservableCollection<AnimalModel>(animalsCollection);
                });
            }
        }
        
        public RelayCommand SerializeFood
        {
            get
            {
                return _serializeFood ??= new RelayCommand(o =>
                {
                    _foodService.Serialize(_foodModels as ICollection<FoodModel>, _foodPath);
                });
            }
        }
        
        public RelayCommand DeserializeFood
        {
            get
            {
                return _deserializeFood ??= new RelayCommand(o =>
                {
                    var foodCollection = _foodService.Deserialize(_foodPath);
                    
                    FoodModels = new ObservableCollection<FoodModel>(foodCollection);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}