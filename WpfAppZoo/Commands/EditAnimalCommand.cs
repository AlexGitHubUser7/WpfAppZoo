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
    public class EditAnimalCommand : AsyncCommandBase
    {
        private readonly AnimalsStore _animalsStore;
        private readonly ModalNavigationStore _modalNavigationSotre;
        private readonly EditAnimalViewModel _editAnimalViewModel;
        public EditAnimalCommand(EditAnimalViewModel editAnimalViewModel, AnimalsStore animalsStore, ModalNavigationStore  modalNavigationSotre)
        {
            _animalsStore = animalsStore;
            _modalNavigationSotre = modalNavigationSotre;
            _editAnimalViewModel = editAnimalViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            AnimalDetailsFormViewModel formViewModel = _editAnimalViewModel.AnimalDetailsFormViewModel;
            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;

            Animal animal = new Animal(
                _editAnimalViewModel.AnimalId,
                formViewModel.AnimalName,
                formViewModel.AnimalSpecies,
                formViewModel.DateOfBirth,
                formViewModel.Gender,
                formViewModel.FavoriteFood,
                formViewModel.IsHealthy);
            try
            {
                await _animalsStore.Update(animal);

                _modalNavigationSotre.Close();
            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Не получилось обновить животное. Пожалуйста, попробуйте позже.";
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }

        }        
    }
}
