using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.ViewModel
{
    public class ReceiptVM:ViewModelBase
    {
        private ReceiptBLL receiptBLL=new ReceiptBLL();
        private ObservableCollection<Receipt> _receipts;
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


        public ReceiptVM()
        {
            _receipts = receiptBLL.GetAllReceipts();
        }

        private Receipt _selectedReceipt;
        public Receipt SelectedReceipt
        {
            get => _selectedReceipt;
            set
            {
                _selectedReceipt = value;
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
