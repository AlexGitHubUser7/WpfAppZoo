using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Domain.Models;
using WpfAppZoo.Stores;
using WpfAppZoo.Views;

namespace WpfAppZoo.ViewModels
{
    public class AnimalsDetailsViewModel : ViewModelBase
    {        
        private readonly SelectedAnimalStore _selectedAnimalStore;
        private Animal SelectedAnimal => _selectedAnimalStore.SelectedAnimal;

        public bool HasSelectedAnimal => SelectedAnimal != null;
        public string AnimalName => SelectedAnimal?.AnimalName ?? "Неизвестно";
        public string AnimalSpecies => SelectedAnimal?.AnimalSpecies ?? "Неизвестно";
        public string DateOfBirth => SelectedAnimal?.DateOfBirth?.ToString("dd.MM.yyyy") ?? "Неизвестна";
        public string Gender => SelectedAnimal?.Gender ?? "Неизвестен";
        public string FavoriteFood => SelectedAnimal?.FavoriteFood ?? "Неизвестно";
        public string IsHealthy => (SelectedAnimal?.IsHealthy ?? false) ? "Здоровоe" : "Больное";


        public AnimalsDetailsViewModel(SelectedAnimalStore selectedAnimalStore)
        {            
           _selectedAnimalStore = selectedAnimalStore;
            _selectedAnimalStore.SelectedAnimalChanged += SelectedAnimalStore_SelectedAnimalChanged;
        }
        protected override void Dispose()
        {
            _selectedAnimalStore.SelectedAnimalChanged -= SelectedAnimalStore_SelectedAnimalChanged;
            base.Dispose();
        }

        private void SelectedAnimalStore_SelectedAnimalChanged()
        {
            OnPropertyChanged(nameof(HasSelectedAnimal));
            OnPropertyChanged(nameof(AnimalName));
            OnPropertyChanged(nameof(AnimalSpecies));
            OnPropertyChanged(nameof(DateOfBirth));
            OnPropertyChanged(nameof(Gender));
            OnPropertyChanged(nameof(FavoriteFood));
            OnPropertyChanged(nameof(IsHealthy));            
        }
    }
}
