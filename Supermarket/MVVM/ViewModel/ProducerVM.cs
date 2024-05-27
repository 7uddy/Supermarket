using GalaSoft.MvvmLight.Command;
using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class ProducerVM:ViewModelBase
    {
        private ProducerBLL producerBLL = new ProducerBLL();
        public ICommand NavigateToAdmin { get; set; }

        public ProducerVM(Navigation navigation, Func<AdminVM> createAdminVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation,createAdminVM);
            _producersList = producerBLL.GetAllProducers();
        }

        private ObservableCollection<Producer> _producersList;
        public ObservableCollection<Producer> ProducersList
        {
            get => _producersList;
            set => _producersList = value;
        }

        private string insertName;
        public string InsertName
        {
            get => insertName;
            set
            {
                insertName = value;
                OnPropertyChanged(nameof(InsertName));
            }
        }

        private string insertCountry;
        public string InsertCountry
        {
            get => insertCountry;
            set
            {
                insertCountry = value;
                OnPropertyChanged(nameof(InsertCountry));
            }
        }

        private RelayCommand insertCommand;
        public ICommand InsertCommand
        {
            get
            {
                if (insertCommand == null)
                {
                    insertCommand = new RelayCommand(() =>
                    {
                        if (insertName == null || insertCountry == null || insertName == "" || insertCountry == "")
                        {
                            MessageBox.Show("Please fill all fields.", "Error", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        producerBLL.InsertProducer(insertName, insertCountry);
                        insertName = null;
                        insertCountry = null;
                        ProducersList = producerBLL.GetAllProducers();
                        OnPropertyChanged(nameof(ProducersList));
                        CloseAction?.Invoke();
                    });
                }
                return insertCommand;
            }
}
        
        private Producer _selectedProducer;
        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                if (_selectedProducer != null)
                {
                    newName = _selectedProducer.Name;
                    newCountry = _selectedProducer.Country;
                }
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        private string newName;
        public string NewName
        {
            get => newName;
            set
            {
                newName = value;
                OnPropertyChanged(nameof(NewName));
            }
        }
        private string newCountry;
        public string NewCountry
        {
            get => newCountry;
            set
            {
                newCountry = value;
                OnPropertyChanged(nameof(NewCountry));
            }
        }

        private RelayCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(() =>
                    {
                        if (newName == null || newCountry == null || newName==""||newCountry=="")
                        {
                            MessageBox.Show("Please fill all fields.", "Error", 
                                                               MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        producerBLL.UpdateProducer(_selectedProducer.Id, newName, newCountry);
                        ProducersList = producerBLL.GetAllProducers();
                        OnPropertyChanged(nameof(ProducersList));
                        CloseAction?.Invoke();
                    });
                }
                return updateCommand;
            }
        }

        private RelayCommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(() =>
                    {
                        producerBLL.DeleteProducer(_selectedProducer.Id);
                        ProducersList = producerBLL.GetAllProducers();
                        OnPropertyChanged(nameof(ProducersList));
                        CloseAction?.Invoke();
                    });
                }
                return deleteCommand;
            }
        }

        public Action CloseAction { get; internal set; }
    }
}
