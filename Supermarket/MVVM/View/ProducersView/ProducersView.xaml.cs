using Supermarket.MVVM.View.ProductsView;
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

namespace Supermarket.MVVM.View.ProducersView
{
    /// <summary>
    /// Interaction logic for ProducersView.xaml
    /// </summary>
    public partial class ProducersView : UserControl
    {
        public ProducersView()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ProducerVM)DataContext;
            ProducersUpdateView producerUpdatePage = new ProducersUpdateView(viewModel);
            producerUpdatePage.ShowDialog();
        }

        private void AddProducerButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ProducerVM)DataContext;
            ProducersInsertView producerInsertPage = new ProducersInsertView(viewModel);
            producerInsertPage.ShowDialog();
        }
    }
}
