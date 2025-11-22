using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.EntityFramework
{
    public class AnimalsDbContextFactory
    {
        
        private readonly DbContextOptions _options;

        public AnimalsDbContextFactory(DbContextOptions options)
        {           
            _options = options;
        }
        public AnimalsDbContext Create()
        {            
            return new AnimalsDbContext(_options);
        }
    }
}
