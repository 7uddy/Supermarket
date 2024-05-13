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

namespace Supermarket.MVVM.View.ProductsView
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ProductVM)DataContext;
            ProductsUpdateView productUpdatePage = new ProductsUpdateView(viewModel);
            productUpdatePage.ShowDialog();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ProductVM)DataContext;
            ProductsInsertView productInsertPage = new ProductsInsertView(viewModel);
            productInsertPage.ShowDialog();
        }
    }

}
