using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppZoo.Stores;
using WpfAppZoo.ViewModels;
using Zoo.Domain.Models;

namespace WpfAppZoo.Commands
{
    public class DeleteAnimalCommand : AsyncCommandBase
    {
        private readonly AnimalsListingItemViewModel _animalsListingItemViewModel;
        private readonly AnimalsStore _animalsStore;        

        public DeleteAnimalCommand(AnimalsListingItemViewModel animalsListingItemViewModel, AnimalsStore animalsStore)
        {
            _animalsListingItemViewModel = animalsListingItemViewModel;
            _animalsStore = animalsStore;            
        }
        
        public override async Task ExecuteAsync(object? parameter)
        {
            _animalsListingItemViewModel.ErrorMessage = null;
            _animalsListingItemViewModel.IsDeleting = true;
            Animal animal = _animalsListingItemViewModel.Animal;

            try
            {
                await _animalsStore.Delete(animal.Id);
            }
            catch (Exception)
            {
                _animalsListingItemViewModel.ErrorMessage = "Не получилось удалить животное.\nПожалуйста, поробуйте позже.";
            }
            finally
            {
                _animalsListingItemViewModel.IsDeleting = false;
            }

        }
    }
}
