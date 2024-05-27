using Supermarket.MVVM.ViewModel;
using System;

namespace Supermarket.Stores
{
    public class Navigation
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        public void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
