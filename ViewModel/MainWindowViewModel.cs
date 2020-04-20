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
        private AnimalModel _selectedAnimal;

        private RelayCommand _serializeAnimals;
        private RelayCommand _deserializeAnimals;
        
        private readonly IOpenCommandAnimal _openAddAnimalWindow;
        private readonly IOpenCommandFood _openCommandFood;

        private readonly string _path;
        
        
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

            _path = ConfigurationManager.AppSettings["SerializationPath"];
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
        
        public RelayCommand SerializeAnimals
        {
            get
            {
                return _serializeAnimals ??= new RelayCommand(o =>
                {
                    _animalService.Serialize(_animalModels as ICollection<AnimalModel>, _path);
                });
            }
        }
        
        public RelayCommand DeserializeAnimals
        {
            get
            {
                return _deserializeAnimals ??= new RelayCommand(o =>
                {
                    var animalsCollection = _animalService.Deserialize(_path);
                    
                    AnimalModels = new ObservableCollection<AnimalModel>(animalsCollection);
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