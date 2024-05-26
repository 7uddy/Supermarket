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

namespace Supermarket.MVVM.View.StocksView
{
    /// <summary>
    /// Interaction logic for StocksView.xaml
    /// </summary>
    public partial class StocksView : UserControl
    {
        public StocksView()
        {
            InitializeComponent();
        }

        private void AddStockButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (StockVM)DataContext;
            StocksInsertView stockInsertPage = new StocksInsertView(viewModel);
            stockInsertPage.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (StockVM)DataContext;
            StocksUpdateView stockUpdatePage = new StocksUpdateView(viewModel);
            stockUpdatePage.Show();
        }
    }
}
