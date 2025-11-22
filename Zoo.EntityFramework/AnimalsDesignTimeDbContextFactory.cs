using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.EntityFramework
{
    public class AnimalsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AnimalsDbContext>
    {
        

        public AnimalsDbContext CreateDbContext(string[] args = null)
        {            
            return new AnimalsDbContext(new DbContextOptionsBuilder().UseSqlite("Date Source=Animals.db").Options);
        }
    }
}
