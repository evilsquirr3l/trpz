using System.Windows.Input;
using Business.Abstract;

namespace ViewModel
{
    public interface IOpenCommandAnimal : ICommand
    {
        public IAnimalService AnimalService { get; set; }
    }

    public interface IOpenCommandFood : ICommand
    {
        public IFoodService FoodService { get; set; }
    }
}