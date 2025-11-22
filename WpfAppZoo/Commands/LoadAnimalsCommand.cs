using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppZoo.Stores;
using WpfAppZoo.ViewModels;

namespace WpfAppZoo.Commands
{
    public class LoadAnimalsCommand : AsyncCommandBase
    {
        private readonly AnimalsViewModel _animalsViewModel;
        private readonly AnimalsStore _animalsStore;

        public LoadAnimalsCommand(AnimalsViewModel animalsViewModel, AnimalsStore animalsStore)
        {
            _animalsViewModel = animalsViewModel;
            _animalsStore = animalsStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            _animalsViewModel.ErrorMessage = null;
            _animalsViewModel.IsLoading = true;
            try
            {                          
                await _animalsStore.Load();
            }
            catch (Exception)
            {
                _animalsViewModel.ErrorMessage = "Не получилось загрузить животных. " +
                    "Пожалуйста, перезагрузите приложение."; 
            }
            finally
            {
                _animalsViewModel.IsLoading = false;
            }
        }
    }
}
