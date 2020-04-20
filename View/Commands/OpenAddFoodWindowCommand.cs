using System;
using System.Windows;
using Business.Abstract;
using ViewModel;

namespace View.Commands
{
    public class OpenAddFoodWindowCommand : IOpenCommandFood
    {
        public event EventHandler CanExecuteChanged;

        public IFoodService FoodService { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App)?.DisplayRootRegistry;

            var filteredWindowViewModel = new AddFoodVM(FoodService);
            displayRootRegistry?.ShowModalPresentation(filteredWindowViewModel);
        }
    }
}