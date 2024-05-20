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
    public class AdminVM:ViewModelBase
    {
        public ICommand NavigateToUser { get; set; }
        public ICommand NavigateToProduct { get; set; }
        public ICommand NavigateToCategory { get; set; }
        public ICommand NavigateToProducer { get; set; }

        public AdminVM(Navigation navigation,Func<UserVM> createUserVM,Func<ProductVM> createProductVM,
            Func<ProductsCategoryVM>createProductsCategoryVM, Func<ProducerVM> createProducerVM)
        {
            NavigateToUser = new NavigateCommand(navigation,createUserVM);
            NavigateToProduct = new NavigateCommand(navigation,createProductVM);
            NavigateToCategory = new NavigateCommand(navigation,createProductsCategoryVM);
            NavigateToProducer = new NavigateCommand(navigation,createProducerVM);
        }

    }
}
