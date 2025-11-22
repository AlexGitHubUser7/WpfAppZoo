using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppZoo.Commands;
using Zoo.Domain.Models;
using WpfAppZoo.Stores;

namespace WpfAppZoo.ViewModels
{
    public class EditAnimalViewModel : ViewModelBase
    {
        public Guid AnimalId { get; }
        public AnimalDetailsFormViewModel AnimalDetailsFormViewModel { get; }

        public EditAnimalViewModel(Animal animal, AnimalsStore animalsStore, ModalNavigationStore modalNavigationStore)
        {
            AnimalId = animal.Id;

            ICommand submitCommand = new EditAnimalCommand(this, animalsStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            AnimalDetailsFormViewModel = new AnimalDetailsFormViewModel(submitCommand, cancelCommand)
            {
                AnimalName = animal.AnimalName,
                AnimalSpecies = animal.AnimalSpecies,
                DateOfBirth = (DateTime)animal.DateOfBirth,
                Gender = animal.Gender,
                FavoriteFood = animal.FavoriteFood,
                IsHealthy = animal.IsHealthy
            };
        }
    }
}
