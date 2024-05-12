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

        public AdminVM(Navigation navigation,Func<UserVM> createUserVM)
        {
            NavigateToUser = new NavigateCommand(navigation,createUserVM);
        }
    }
}
