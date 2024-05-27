using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class ReceiptVM:ViewModelBase
    {
        private ReceiptBLL receiptBLL=new ReceiptBLL();
        private ObservableCollection<Receipt> _receipts;

        public ICommand NavigateToCashier { get; set; }
        public ObservableCollection<Receipt> Receipts
        {
            get => _receipts;
            set
            {
                _receipts = value;
                if(_receipts!=null)
                {
                    UpdateDetails();
                }
                OnPropertyChanged("Receipts");
            }
        }


        public ReceiptVM(Navigation navigation,Func<CashierVM> createCashierVM)
        {
            _receipts = receiptBLL.GetAllReceipts();
            NavigateToCashier = new NavigateCommand(navigation, createCashierVM);
        }

        private Receipt _selectedReceipt;
        public Receipt SelectedReceipt
        {
            get => _selectedReceipt;
            set
            {
                _selectedReceipt = value;
                UpdateDetails();
                OnPropertyChanged("SelectedReceipt");
            }
        }

        private ReceiptProductBLL receiptProductBLL = new ReceiptProductBLL();  

        private ObservableCollection<ReceiptProduct> _selectedReceiptProducts;
        public ObservableCollection<ReceiptProduct> SelectedReceiptProducts
        {
            get => _selectedReceiptProducts;
            set
            {
                _selectedReceiptProducts = value;
                OnPropertyChanged("SelectedReceiptProducts");
            }
        }

        public Action CloseAction { get; internal set; }

        private void UpdateDetails()
        {
            _selectedReceiptProducts = receiptProductBLL.GetReceiptProducts(_selectedReceipt);
        }

    }
}
