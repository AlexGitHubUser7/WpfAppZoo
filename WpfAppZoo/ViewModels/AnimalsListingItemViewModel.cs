using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppZoo.Commands;
using Zoo.Domain.Models;
using WpfAppZoo.Stores;

namespace WpfAppZoo.ViewModels
{
    public class AnimalsListingItemViewModel : ViewModelBase
    {
        public Animal Animal { get; private set; }
        public string AnimalName => Animal.AnimalName;

        private bool _isDeleting;

        public bool IsDeleting
        {
            get 
            { 
                return _isDeleting; 
            }
            set 
            {  
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand{ get; }
        
        public AnimalsListingItemViewModel(Animal animal, AnimalsStore animalsStore, ModalNavigationStore modalNavigationStore)
        {
            Animal = animal;

            EditCommand = new OpenEditAnimalCommand(this, animalsStore, modalNavigationStore);
            DeleteCommand = new DeleteAnimalCommand(this, animalsStore);
        }

        public void Update(Animal animal)
        {
            Animal = animal;
            OnPropertyChanged(nameof(AnimalName));
        }
    }
}
