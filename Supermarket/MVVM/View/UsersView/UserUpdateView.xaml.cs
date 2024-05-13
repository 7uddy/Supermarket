using Supermarket.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Supermarket.MVVM.View
{
    /// <summary>
    /// Interaction logic for UserUpdateView.xaml
    /// </summary>
    public partial class UserUpdateView : Window
    {
        public UserUpdateView(UserVM userViewModel)
        {
            InitializeComponent();
            this.DataContext = userViewModel;
            userViewModel.CloseAction = new Action(this.Close);
        }
    }
}
