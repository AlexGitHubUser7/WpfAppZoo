using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppZoo.Stores;
using WpfAppZoo.ViewModels;

namespace WpfAppZoo.Commands
{
    public class OpenAddAnimalCommand : CommandBase
    {
        private readonly AnimalsStore _animalsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddAnimalCommand(AnimalsStore animalsStore, ModalNavigationStore modalNavigationSotre)
        {
            _animalsStore = animalsStore;
            _modalNavigationStore = modalNavigationSotre;
        }

        public override void Execute(object? parameter)
        {
            AddAnimalViewModel addAnimalViewModel = new AddAnimalViewModel(_animalsStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addAnimalViewModel;
        }
    }
}
