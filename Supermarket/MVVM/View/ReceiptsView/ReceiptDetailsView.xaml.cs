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

namespace Supermarket.MVVM.View.ReceiptsView
{
    /// <summary>
    /// Interaction logic for ReceiptDetailsView.xaml
    /// </summary>
    public partial class ReceiptDetailsView : Window
    {
        public ReceiptDetailsView(ReceiptVM receiptVM)
        {
            InitializeComponent();
            this.DataContext = receiptVM;
            receiptVM.CloseAction = new Action(this.Close);
        }
    }
}
