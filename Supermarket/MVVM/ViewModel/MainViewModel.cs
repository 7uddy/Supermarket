﻿using Supermarket.Stores;

namespace Supermarket.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Navigation _navigation;
        public ViewModelBase CurrentViewModel => _navigation.CurrentViewModel;
        public MainViewModel(Navigation navigation)
        {
            _navigation = navigation;
            _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
