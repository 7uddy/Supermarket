﻿using Supermarket.MVVM.Model.EntityLayer;
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

namespace Supermarket.MVVM.View.ProducersView
{
    /// <summary>
    /// Interaction logic for ProducersInsertView.xaml
    /// </summary>
    public partial class ProducersInsertView : Window
    {
        public ProducersInsertView(ProducerVM producerVM)
        {
            InitializeComponent();
            this.DataContext = producerVM;
            producerVM.CloseAction = new Action(this.Close);
        }
    }
}
