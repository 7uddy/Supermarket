using GalaSoft.MvvmLight.Command;
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
        public ICommand NavigateToCreateReceipt { get; set; }
        public CashierVM(Navigation navigation,Func<ReceiptVM> createReceiptVM,Func<CreateReceiptVM> createCreateReceiptVM)
        {
            NavigateToReceipt = new NavigateCommand(navigation, createReceiptVM);
            NavigateToCreateReceipt = new NavigateCommand(navigation, createCreateReceiptVM);
        }
    }
}
