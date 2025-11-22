using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.EntityFramework.DTOs
{
    public class AnimalDto
    {        
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public string AnimalSpecies { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string FavoriteFood { get; set; }
        public bool IsHealthy { get; set; }
    }
}
