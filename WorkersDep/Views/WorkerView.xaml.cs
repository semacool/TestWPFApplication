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
    /// Логика взаимодействия для WorkerView.xaml
    /// </summary>
    public partial class WorkerView : Window
    {
        public WorkerView(Department department)
        {
            DataContext = new WorkerVIewModel(this.Close, department);
            InitializeComponent();
        }

        public WorkerView(Worker worker)
        {
            DataContext = new WorkerVIewModel(this.Close,worker.Id);
            InitializeComponent();
        }
    }
}
