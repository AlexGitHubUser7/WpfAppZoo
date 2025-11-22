using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Models;
using Zoo.EntityFramework.DTOs;

namespace Zoo.EntityFramework
{
    public class AnimalsDbContext : DbContext
    {
        public AnimalsDbContext(DbContextOptions options) : base(options) { }       
        public DbSet<AnimalDto> Animals { get; set; }
    }
}
