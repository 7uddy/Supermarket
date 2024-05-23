using Supermarket.Commands;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class CashierVM:ViewModelBase
    {
        public ICommand NavigateToReceipt { get; set; }
        public CashierVM(Navigation navigation,Func<ReceiptVM> createReceiptVM)
        {
            NavigateToReceipt = new NavigateCommand(navigation, createReceiptVM);
        }
    }
}
