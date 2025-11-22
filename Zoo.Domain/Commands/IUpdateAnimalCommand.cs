using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Models;

namespace Zoo.Domain.Commands
{
    public interface IUpdateAnimalCommand
    {
        Task Execute(Animal animal);
    }
}
