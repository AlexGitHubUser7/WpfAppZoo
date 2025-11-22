using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Models;

namespace WpfAppZoo.Stores
{
    public class SelectedAnimalStore
    {
        private readonly AnimalsStore _animalsStore;
        private Animal _selectedAnimal;

        public Animal SelectedAnimal 
        { 
            get 
            { 
                return _selectedAnimal; 
            }
            set 
            { 
                _selectedAnimal = value;
                SelectedAnimalChanged?.Invoke();
            }
        }
        public event Action SelectedAnimalChanged;

        public SelectedAnimalStore(AnimalsStore animalsStore)
        {
            _animalsStore = animalsStore;

            _animalsStore.AnimalAdded += AnimalsStore_AnimalAdded;
            _animalsStore.AnimalUpdated += AnimalsStore_AnimalUpdated;
        }

        private void AnimalsStore_AnimalAdded(Animal animal)
        {
            SelectedAnimal = animal;
        }

        private void AnimalsStore_AnimalUpdated(Animal animal)
        {
            if(animal.Id == SelectedAnimal?.Id)
            {
                SelectedAnimal = animal;
            }
        }
    }
}
