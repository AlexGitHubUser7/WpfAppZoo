using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Domain.Models
{
    public class Animal
    {
        
        public Guid Id { get; }
        public string? AnimalName { get;}
        public string? AnimalSpecies {  get;}
        public DateTime? DateOfBirth { get;}        
        public string? Gender { get; }
        public string? FavoriteFood { get; }
        public bool IsHealthy { get; }
       
        public Animal(Guid id, string animalName, string animalSpecies, DateTime dateOfBirth, string gender, string favoriteFood, bool isHealthy)
        {
            Id = id;
            AnimalName = animalName;
            AnimalSpecies = animalSpecies;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            FavoriteFood = favoriteFood;
            IsHealthy = isHealthy;
        }

    }
}
