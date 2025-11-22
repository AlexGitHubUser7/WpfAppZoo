using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Models;
using WpfAppZoo.Stores;
using WpfAppZoo.ViewModels;

namespace WpfAppZoo.Commands
{
    public class AddAnimalCommand : AsyncCommandBase
    {
        private readonly AddAnimalViewModel _addAnimalViewModel;
        private readonly AnimalsStore _animalsStore;
        private readonly ModalNavigationStore _modalNavigationSotre;
        public AddAnimalCommand(AddAnimalViewModel addAnimalViewModel, AnimalsStore animalsStore, ModalNavigationStore  modalNavigationSotre)
        {
            _addAnimalViewModel = addAnimalViewModel;
            _animalsStore = animalsStore;
            _modalNavigationSotre = modalNavigationSotre;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            AnimalDetailsFormViewModel formViewModel = _addAnimalViewModel.AnimalDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;

            Animal animal = new Animal(
                Guid.NewGuid(),
                formViewModel.AnimalName, 
                formViewModel.AnimalSpecies,
                formViewModel.DateOfBirth,
                formViewModel.Gender,
                formViewModel.FavoriteFood,
                formViewModel.IsHealthy);
            try
            {
                await _animalsStore.Add(animal);

                _modalNavigationSotre.Close();
            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Не получилось добавить животное. Пожалуйста, попробуйте позже.";
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
           
        }
        
    }
}
