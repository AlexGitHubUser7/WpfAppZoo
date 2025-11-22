using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppZoo.Stores;

namespace WpfAppZoo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public AnimalsViewModel AnimalsViewModel { get; }
        public MainViewModel(ModalNavigationStore modalNavigationStore, AnimalsViewModel animalsViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            AnimalsViewModel = animalsViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationSotre_CurrentViewModelChanged;            
        }
        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationSotre_CurrentViewModelChanged;
            base.Dispose();
        }
        
        private void ModalNavigationSotre_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
