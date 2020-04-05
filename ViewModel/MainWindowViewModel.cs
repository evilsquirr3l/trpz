using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using BLL.Interfaces;
using BLL.Models;

namespace WpfLibrary
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IAnimalService _animalService;
        private readonly ITimeService _timeService;
        private RelayCommand _feedCommand;
        private readonly IFoodService _foodService;
        private RelayCommand _shiftTimeCommand;

        private ObservableCollection<FoodModel> _suitableFood;
        private AnimalModel _selectedAnimal;
        private ObservableCollection<AnimalModel> _hungry;
        private DateTime _currentTime;

        public MainWindowViewModel(ITimeService timeService, IAnimalService animalService, IFoodService foodService)
        {
            _timeService = timeService;
            _animalService = animalService;
            _foodService = foodService;
            _currentTime = _timeService.CurrentTime;

            _hungry = new ObservableCollection<AnimalModel>(_animalService.GetHungryAnimals());
            _foodModels = new ObservableCollection<FoodModel>(_foodService.GetAll());
            _animalModels = new ObservableCollection<AnimalModel>(_animalService.GetAllAnimals());
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

        private ObservableCollection<AnimalModel> _animalModels;
        private ObservableCollection<FoodModel> _foodModels;

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

        private void UpdateWindow()
        {
            AnimalModels = new ObservableCollection<AnimalModel>(_animalService.GetAllAnimals());
            Hungry = new ObservableCollection<AnimalModel>(_animalService.GetHungryAnimals());
            FoodModels = new ObservableCollection<FoodModel>(_foodService.GetAll());
            CurrentTime = _timeService.CurrentTime;
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
            get { return _selectedAnimal; }
            set
            {
                _selectedAnimal = value;
                GetSuitableFood();
                OnPropertyChanged();
            }
        }

        public FoodModel SelectedFoodModel { get; set; }

        public RelayCommand FeedAnimal
        {
            get
            {
                return _feedCommand ??=
                    new RelayCommand(o =>
                    {
                        _animalService.FeedAnimal(SelectedAnimal.Id, SelectedFoodModel);

                        MessageBox.Show($"Покормил {SelectedAnimal.Name}", "Info", MessageBoxButton.OK,
                            MessageBoxImage.Information);


                        SelectedFoodModel = null;
                        SuitableFood = null;
                        UpdateWindow();
                    }, o => SelectedFoodModel != null);
            }
        }

        public RelayCommand ShiftTime
        {
            get { return _shiftTimeCommand ??= new RelayCommand(o =>
            {
                _timeService.ShiftTime(Hours);
                UpdateWindow();
            }, o => Hours != 0); 
            }
        }

        private void GetSuitableFood()
        {
            var food = _foodService.GetSuitableFoodForAnimal(SelectedAnimal.Id);

            SuitableFood = new ObservableCollection<FoodModel>(food);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}