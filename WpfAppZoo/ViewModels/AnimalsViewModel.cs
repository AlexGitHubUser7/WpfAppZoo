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
    public class AnimalsViewModel : ViewModelBase
    {
        public AnimalsListingViewModel AnimalsListingViewModel { get; }
        public AnimalsDetailsViewModel AnimalsDetailsViewModel { get; }

        private bool _isLoading;        
        public bool IsLoading
        {
            get 
            { 
                return _isLoading; 
            }
            set 
            {  
                _isLoading = value; 
                OnPropertyChanged(nameof(IsLoading));
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

        public ICommand LoadAnimalsCommand { get; }
        public ICommand AddAnimalsCommand { get; }

        public AnimalsViewModel(AnimalsStore animalsStore, SelectedAnimalStore selectedAnimalStore, ModalNavigationStore modalNavigationStore)
        {
            AnimalsListingViewModel = new AnimalsListingViewModel(animalsStore, selectedAnimalStore, modalNavigationStore);
            AnimalsDetailsViewModel = new AnimalsDetailsViewModel(selectedAnimalStore);

            LoadAnimalsCommand = new LoadAnimalsCommand(this, animalsStore);
            AddAnimalsCommand = new OpenAddAnimalCommand(animalsStore, modalNavigationStore);
        }
        public static AnimalsViewModel LoadViewModel(AnimalsStore animalsStore,
            SelectedAnimalStore selectedAnimalStore,
            ModalNavigationStore modalNavigationStore)
        {
            AnimalsViewModel viewModel = new AnimalsViewModel(animalsStore, selectedAnimalStore, modalNavigationStore);
            viewModel.LoadAnimalsCommand.Execute(null);
            return viewModel;
        }
    }
}
