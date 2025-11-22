using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Commands;
using Zoo.Domain.Models;
using Zoo.EntityFramework.DTOs;

namespace Zoo.EntityFramework.Commands
{
    public class UpdateAnimalCommand : IUpdateAnimalCommand
    {
        private readonly AnimalsDbContextFactory _contextFactory;

        public UpdateAnimalCommand(AnimalsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task Execute(Animal animal)
        {            
            using (AnimalsDbContext context = _contextFactory.Create())
            {
                AnimalDto animalDto = new AnimalDto()
                {
                    Id = animal.Id,
                    AnimalName = animal.AnimalName,
                    AnimalSpecies = animal.AnimalSpecies,
                    DateOfBirth = (DateTime)animal.DateOfBirth,
                    Gender = animal.Gender,
                    FavoriteFood = animal.FavoriteFood,
                    IsHealthy = animal.IsHealthy,
                };

                context.Animals.Update(animalDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
