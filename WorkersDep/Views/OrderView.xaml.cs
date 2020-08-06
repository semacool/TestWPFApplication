using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkersDep.Models;
using WorkersDep.ViewModels;

namespace WorkersDep.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {

        public OrderView(Worker worker)
        {
            DataContext = new OrderViewModel(this.Close,worker);
            InitializeComponent();
        }

        public OrderView(Order order)
        {
            DataContext = new OrderViewModel(this.Close,order.Id);
            InitializeComponent();
        }
    }
}
