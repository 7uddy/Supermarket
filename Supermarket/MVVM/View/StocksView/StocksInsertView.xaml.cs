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

namespace Supermarket.MVVM.View.StocksView
{
    /// <summary>
    /// Interaction logic for StocksInsertView.xaml
    /// </summary>
    public partial class StocksInsertView : Window
    {
        public StocksInsertView(StockVM stockVM)
        {
            InitializeComponent();
            this.DataContext = stockVM;
            stockVM.CloseAction = new Action(this.Close);
        }
    }
}
