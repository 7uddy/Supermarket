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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Supermarket.MVVM.View
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (UserVM)DataContext;
            UserInsertView userInsertPage = new UserInsertView(viewModel);
            userInsertPage.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (UserVM)DataContext;
            UserUpdateView userUpdatePage = new UserUpdateView(viewModel);
            userUpdatePage.Show();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (UserVM)DataContext;
            UserInsertView userInsertView= new UserInsertView(viewModel);
            userInsertView.Show();
        }
    }
}
