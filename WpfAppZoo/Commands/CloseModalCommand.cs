using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppZoo.Stores;

namespace WpfAppZoo.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly ModalNavigationStore    _modalNavigationSotre;
        public CloseModalCommand(ModalNavigationStore modalNavigationSotre)
        {
            _modalNavigationSotre = modalNavigationSotre;
        }
        public override void Execute(object? parameter)
        {
            _modalNavigationSotre.Close();
        }
    }
}
