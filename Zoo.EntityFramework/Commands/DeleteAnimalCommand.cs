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
    public class DeleteAnimalCommand : IDeleteAnimalCommand
    {
        private readonly AnimalsDbContextFactory _contextFactory;

        public DeleteAnimalCommand(AnimalsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task Execute(Guid id)
        {
            using (AnimalsDbContext context = _contextFactory.Create())
            {              
                AnimalDto animalDto = new AnimalDto()
                {
                    Id = id,                
                };

                context.Animals.Remove(animalDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
