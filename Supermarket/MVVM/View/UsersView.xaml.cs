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
            UserInsertPage userInsertPage = new UserInsertPage();
            userInsertPage.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            UserUpdatePage userUpdatePage = new UserUpdatePage();
            userUpdatePage.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
