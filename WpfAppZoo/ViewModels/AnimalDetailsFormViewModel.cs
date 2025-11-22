using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppZoo.ViewModels
{
    public class AnimalDetailsFormViewModel : ViewModelBase
    {
        private string _animalName;
        private string _animalSpecies;
        private DateTime _dateOfBirth;
        private string _gender;
        private string _favoriteFood;
        private bool _isHealthy;


        public string AnimalName
        {
            get
            {
                return _animalName;
            }
            set
            {
                _animalName = value;
                OnPropertyChanged(nameof(AnimalName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
        public string AnimalSpecies 
        {
            get
            {
                return _animalSpecies;
            }
            set
            {
                _animalSpecies = value;
                OnPropertyChanged(nameof(AnimalSpecies));
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));                
            }
        }
        public bool IsHealthy
        {
            get
            {
                return _isHealthy;
            }
            set
            {
                _isHealthy = value;
                OnPropertyChanged(nameof(IsHealthy));
            }
        }
        public string FavoriteFood
        {
            get
            {
                return _favoriteFood;
            }
            set
            {
                _favoriteFood = value;
                OnPropertyChanged(nameof(FavoriteFood));
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
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
        public bool CanSubmit => !string.IsNullOrEmpty(AnimalName);
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public AnimalDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
