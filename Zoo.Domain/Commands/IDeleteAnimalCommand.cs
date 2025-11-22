using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Domain.Commands
{
    public interface IDeleteAnimalCommand
    {
        Task Execute(Guid id);
    }
}
