using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL.Interfaces;
using BLL.Models;

namespace WpfLibrary
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IAnimalService _animalService;
        private ITimeService _timeService;
        private RelayCommand _command;

        public ObservableCollection<AnimalModel> AnimalModels => new ObservableCollection<AnimalModel>(_animalService.GetAllAnimals()); 

        public ObservableCollection<FoodModel> FoodModels { get; set; }

        public AnimalModel SelectedAnimal { get; set; }

        public FoodModel SelectedFoodModel { get; set; }

        

        public MainWindowViewModel(ITimeService timeService, IAnimalService animalService)
        {
            _timeService = timeService;
            _animalService = animalService;
        }

        public RelayCommand FeedAnimals
        {
            get
            {
                return _command ??= new RelayCommand(o => _animalService.FeedAnimal(SelectedAnimal.Id, SelectedFoodModel));
            }
        }

        public ObservableCollection<AnimalModel> Animals { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}