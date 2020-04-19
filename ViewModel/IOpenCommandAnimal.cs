using System.Windows.Input;
using BLL.Interfaces;

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