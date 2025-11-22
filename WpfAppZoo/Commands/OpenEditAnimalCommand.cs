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
    public class OpenEditAnimalCommand : CommandBase
    {        
        private readonly AnimalsListingItemViewModel _animalsListingItemViewModel;
        private readonly AnimalsStore _animalsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditAnimalCommand(AnimalsListingItemViewModel animalsListingItemViewModel,
            AnimalsStore animalsStore,
            ModalNavigationStore modalNavigationSotre)
        {
            _animalsListingItemViewModel = animalsListingItemViewModel;
            _animalsStore = animalsStore;
            _modalNavigationStore = modalNavigationSotre;
        }
        public override void Execute(object? parameter)
        {
            Animal animal = _animalsListingItemViewModel.Animal;

            EditAnimalViewModel editAnimalViewModel = 
                new EditAnimalViewModel(animal,_animalsStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editAnimalViewModel;
        }
    }
}
