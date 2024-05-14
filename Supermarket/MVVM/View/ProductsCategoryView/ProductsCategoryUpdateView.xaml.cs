using Supermarket.MVVM.Model.EntityLayer;
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

namespace Supermarket.MVVM.View.ProductsCategoryView
{
    /// <summary>
    /// Interaction logic for ProductsCategoryUpdateView.xaml
    /// </summary>
    public partial class ProductsCategoryUpdateView : Window
    {
        public ProductsCategoryUpdateView(ProductsCategoryVM productCategoryVM)
        {
            InitializeComponent();
            this.DataContext = productCategoryVM;
            productCategoryVM.CloseAction = new Action(this.Close);
        }
    }
}
