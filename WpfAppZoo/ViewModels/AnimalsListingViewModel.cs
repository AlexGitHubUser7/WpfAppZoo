using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppZoo.Commands;
using Zoo.Domain.Models;
using WpfAppZoo.Stores;

namespace WpfAppZoo.ViewModels
{
    public class AnimalsListingViewModel : ViewModelBase
    {
        private readonly AnimalsStore _animalsStore;
        private readonly SelectedAnimalStore _selectedAnimalStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ObservableCollection<AnimalsListingItemViewModel> _animalsListingItemViewModels;
        public IEnumerable<AnimalsListingItemViewModel> AnimalsListingItemViewModels => 
            _animalsListingItemViewModels;
       
        public AnimalsListingItemViewModel SelectedAnimalListingItemViewModel
        {
            get 
            { 
                return _animalsListingItemViewModels
                    .FirstOrDefault(y => y.Animal?.Id == _selectedAnimalStore.SelectedAnimal?.Id); 
            }
            set
            {       
                _selectedAnimalStore.SelectedAnimal = value?.Animal;                
            }
        }       

        public AnimalsListingViewModel(AnimalsStore animalsStore, SelectedAnimalStore selectedAnimalStore, ModalNavigationStore modalNavigationSotre)
        {
            _animalsStore = animalsStore;
            _selectedAnimalStore = selectedAnimalStore;
            _modalNavigationStore = modalNavigationSotre;
            _animalsListingItemViewModels = new ObservableCollection<AnimalsListingItemViewModel>();

            _selectedAnimalStore.SelectedAnimalChanged += SelectedAnimalStore_SelectedAnimalChanged;

            _animalsStore.AnimalsLoaded += AnimalsStore_AnimalsLoaded;
            _animalsStore.AnimalAdded += AnimalsStore_AnimalAdded;
            _animalsStore.AnimalUpdated += AnimalsStore_AnimalUpdated;
            _animalsStore.AnimalDeleted += AnimalsStore_AnimalDeleted;

            _animalsListingItemViewModels.CollectionChanged += AnimalsListingItemViewModels_CollectionChanged;    
        }
        protected override void Dispose()
        {
            _selectedAnimalStore.SelectedAnimalChanged -= SelectedAnimalStore_SelectedAnimalChanged;
            _animalsStore.AnimalsLoaded -= AnimalsStore_AnimalsLoaded;
            _animalsStore.AnimalAdded -= AnimalsStore_AnimalAdded;
            _animalsStore.AnimalUpdated -= AnimalsStore_AnimalUpdated;
            _animalsStore.AnimalDeleted -= AnimalsStore_AnimalDeleted;
            base.Dispose();
        }
        private void SelectedAnimalStore_SelectedAnimalChanged()
        {
            OnPropertyChanged(nameof(SelectedAnimalListingItemViewModel));
        }
        private void AnimalsStore_AnimalsLoaded()
        {
            _animalsListingItemViewModels.Clear();
            foreach (Animal animal in _animalsStore.Animals)
            {
                AddAnimal(animal);
            }
        }
        private void AnimalsStore_AnimalAdded(Animal animal)
        {
            AddAnimal(animal);
        }
        private void AnimalsStore_AnimalUpdated(Animal animal)
        {
           AnimalsListingItemViewModel animalViewModel = 
                _animalsListingItemViewModels.FirstOrDefault(y => y.Animal.Id == animal.Id);
            
            if(animalViewModel != null)
            {
                animalViewModel.Update(animal);
            }
        }
        private void AnimalsStore_AnimalDeleted(Guid id)
        {
            AnimalsListingItemViewModel itemViewModel = _animalsListingItemViewModels.FirstOrDefault(y => y.Animal?.Id == id);
            if(itemViewModel != null)
            {
                _animalsListingItemViewModels.Remove(itemViewModel);
            }
        }
        private void AnimalsListingItemViewModels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedAnimalListingItemViewModel));
        }
        private void AddAnimal(Animal animal)
        {
            AnimalsListingItemViewModel itemViewModel = 
                new AnimalsListingItemViewModel(animal, _animalsStore, _modalNavigationStore);
            _animalsListingItemViewModels.Add(itemViewModel);
        }
    }
}
