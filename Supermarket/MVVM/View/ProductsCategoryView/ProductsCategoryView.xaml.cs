using Supermarket.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Supermarket.MVVM.View.ProductsCategoryView
{
    /// <summary>
    /// Interaction logic for ProductsCategoryView.xaml
    /// </summary>
    public partial class ProductsCategoryView : UserControl
    {
        public ProductsCategoryView()
        {
            InitializeComponent();
            TotalProductsPrice.Visibility = Visibility.Collapsed;
        }

        private void AddProductCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ProductsCategoryVM)DataContext;
            ProductsCategoryInsertView productCategoryInsertPage = new ProductsCategoryInsertView(viewModel);
            productCategoryInsertPage.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ProductsCategoryVM)DataContext;
            ProductsCategoryUpdateView productCategoryUpdatePage = new ProductsCategoryUpdateView(viewModel);
            productCategoryUpdatePage.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TotalProductsPrice.Visibility==Visibility.Visible)
            {
                TotalProductsPrice.Visibility = Visibility.Collapsed;
            }
            else
            {
                TotalProductsPrice.Visibility = Visibility.Visible;
            }
        }
    }
}
