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
                OnPropertyChanged("Receipts");
            }
        }
        public ReceiptVM()
        {
            _receipts = receiptBLL.GetAllReceipts();
        }
    }
}
