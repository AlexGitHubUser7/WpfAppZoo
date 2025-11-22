using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Commands;
using Zoo.Domain.Models;
using Zoo.Domain.Queries;

namespace WpfAppZoo.Stores
{
    public class AnimalsStore
    {
        private readonly ICreateAnimalCommand _createAnimalCommand; 
        private readonly IUpdateAnimalCommand _updateAnimalCommand;
        private readonly IDeleteAnimalCommand _deleteAnimalCommand;
        private readonly IGetAllAnimalsQuery _getAllAnimalsQuery;

        private readonly List<Animal> _animals;
        public IEnumerable<Animal> Animals => _animals;
        
        public event Action AnimalsLoaded;
        public event Action<Animal> AnimalAdded;
        public event Action<Animal> AnimalUpdated;
        public event Action<Guid> AnimalDeleted;

        public AnimalsStore(IGetAllAnimalsQuery getAllAnimalsQuery, 
            IUpdateAnimalCommand updateAnimalCommand, 
            IDeleteAnimalCommand deleteAnimalCommand, 
            ICreateAnimalCommand createAnimalCommand)
        {
            _getAllAnimalsQuery = getAllAnimalsQuery;
            _updateAnimalCommand = updateAnimalCommand;
            _deleteAnimalCommand = deleteAnimalCommand;
            _createAnimalCommand = createAnimalCommand;

            _animals = new List<Animal>();
        }
        public async Task Load()
        {
            IEnumerable<Animal> animals = await _getAllAnimalsQuery.Execute();

            _animals.Clear();
            _animals.AddRange(animals);

            AnimalsLoaded?.Invoke();
        }
        public async Task Add(Animal animal)
        {
            await _createAnimalCommand.Execute(animal);

            _animals.Add(animal);

            AnimalAdded?.Invoke(animal);
        }


        public async Task Update(Animal animal)
        {
            await _updateAnimalCommand.Execute(animal);

            int currentIndex = _animals.FindIndex(y => y.Id == animal.Id);

            if(currentIndex != -1)
            {
                _animals[currentIndex] = animal;
            }
            else
            {
                _animals.Add(animal);
            }

            AnimalUpdated?.Invoke(animal);
        }
        public async Task Delete(Guid id)
        {
            await _deleteAnimalCommand.Execute(id);
            
            _animals.RemoveAll(y => y.Id == id);

            AnimalDeleted?.Invoke(id);
        }
    }
}
