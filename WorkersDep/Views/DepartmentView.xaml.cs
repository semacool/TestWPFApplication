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
    /// Логика взаимодействия для DepartmentView.xaml
    /// </summary>
    public partial class DepartmentView : Window
    {
        public DepartmentView()
        {
            DataContext = new DepartmentViewModel(this.Close);
            InitializeComponent();
        }

        public DepartmentView(Department department)
        {
            DataContext = new DepartmentViewModel(department.Id, this.Close);
            InitializeComponent();
        }
    }
}
