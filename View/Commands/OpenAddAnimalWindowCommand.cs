using System;
using System.Windows;
using Business.Abstract;
using ViewModel;

namespace View.Commands
{
    public class OpenAddAnimalWindowCommand : IOpenCommandAnimal
    {

        public event EventHandler CanExecuteChanged;

        public IAnimalService AnimalService { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App)?.DisplayRootRegistry;

            var filteredWindowViewModel = new AddAnimalVM(AnimalService);
            displayRootRegistry?.ShowModalPresentation(filteredWindowViewModel);
        }
    }
}