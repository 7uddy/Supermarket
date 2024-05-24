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

namespace Supermarket.MVVM.View.CreateReceiptView
{
    /// <summary>
    /// Interaction logic for CreateReceiptInsertView.xaml
    /// </summary>
    public partial class CreateReceiptInsertView : Window
    {
        public CreateReceiptInsertView(CreateReceiptVM createReceiptVM)
        {
            InitializeComponent();
            this.DataContext = createReceiptVM;
            createReceiptVM.CloseAction = new Action(this.Close);
        }
    }
}
