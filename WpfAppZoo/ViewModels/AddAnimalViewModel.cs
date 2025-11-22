using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppZoo.Commands;
using WpfAppZoo.Stores;

namespace WpfAppZoo.ViewModels
{
    public class AddAnimalViewModel : ViewModelBase
    {
        public AnimalDetailsFormViewModel AnimalDetailsFormViewModel { get; }

        public AddAnimalViewModel(AnimalsStore animalsStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddAnimalCommand(this, animalsStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            AnimalDetailsFormViewModel = new AnimalDetailsFormViewModel(submitCommand, cancelCommand);           
        }
    }
}
