using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Models;
using Zoo.Domain.Queries;
using Zoo.EntityFramework.DTOs;


namespace Zoo.EntityFramework.Queries
{
    public class GetAllAnimalsQuery : IGetAllAnimalsQuery
    {
        private readonly AnimalsDbContextFactory _contextFactory;

        public GetAllAnimalsQuery(AnimalsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Animal>> Execute()
        {            
            using (AnimalsDbContext context = _contextFactory.Create())
            {             

                IEnumerable<AnimalDto> animalDtos = await context.Animals.ToListAsync();

                return animalDtos.Select(y => new Animal(y.Id, y.AnimalName, y.AnimalSpecies, y.DateOfBirth, y.Gender, y.FavoriteFood, y.IsHealthy));
            }
        }
    }
}
