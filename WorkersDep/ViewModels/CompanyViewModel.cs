using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkersDep.Models;
using WorkersDep.Services.DataBaseService;
using WorkersDep.Services.DelegateCommand;
using WorkersDep.Services.Provider;

namespace WorkersDep.ViewModels
{
    class CompanyViewModel : ViewModel
    {
        DataBaseService DataService;
        #region privateProp
        private Worker selectedWorker;
        private Department selectedDepartment;
        private Order selectedOrder;
        private ObservableCollection<Worker> workers;
        private ObservableCollection<Department> departments;
        private ObservableCollection<Order> orders;
        #endregion

        public Worker SelectedWorker
        {
            get => selectedWorker;
            set
            {
                selectedWorker = value;
                OnPropertyChanged(nameof(SelectedWorker));
            }
        }
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;
                OnPropertyChanged(nameof(SelectedDepartment));
            }
        }
        public Order SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;

                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public ObservableCollection<Worker> Workers
        {
            get => workers;
            set
            {
                workers = value;
                OnPropertyChanged(nameof(Workers));
            }
        }
        public ObservableCollection<Department> Departments
        {
            get => departments;
            set
            {
                departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }
        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public CompanyViewModel()
        {
            DataService = new DataBaseService();
            UpdateAll();
        }

        private void ClickAdd(object param)
        {
            Provider.OpenWindow(param);
            switch (param.GetType().Name)
            {
                case "String":
                    UpdateAll();
                    break;
                case "Department":
                    UpdateWorkers();
                    break;
                case "Worker":
                    UpdateOrders();
                    break;
            }
        }
        private void ClickOpen(object param)
        {
            Provider.OpenWindowParam(param);
            switch (param.GetType().Name)
            {
                case "Department":
                    UpdateAll();
                    break;
                case "Worker":
                    UpdateWorkers();
                    break;
                case "Order":
                    UpdateOrders();
                    break;
            }
        }

        #region Clicks_Department
        public DelegateCommand Click_AddDepartment => new DelegateCommand(ClickAdd);
        public DelegateCommand Click_Department => new DelegateCommand(ClickOpen, CanOpenDepartment);
        bool CanOpenDepartment(object param)
        {
            return SelectedDepartment != null;
        }
        #endregion

        #region Clicks_Worker
        public DelegateCommand Click_AddWorker => new DelegateCommand(ClickAdd, CanOpenAddWorker);
        bool CanOpenAddWorker(object param)
        {
            return SelectedDepartment != null;
        }
        public DelegateCommand Click_Worker => new DelegateCommand(ClickOpen, CanOpenWorker);
        bool CanOpenWorker(object param)
        {
            return SelectedWorker != null;
        }
        #endregion

        #region Clicks_Order
        public DelegateCommand Click_AddOrder => new DelegateCommand(ClickAdd, CanOpenAddOrder);
        bool CanOpenAddOrder(object param)
        {
            return SelectedWorker != null;
        }
        public DelegateCommand Click_Order => new DelegateCommand(ClickOpen, CanOpenOrder);
        bool CanOpenOrder(object param)
        {
            return SelectedOrder != null;
        }
        #endregion

        #region UpdateMethods
        public void UpdateAll()
        {
            Departments = new ObservableCollection<Department>
            (
               DataService.GetDepartments()
            );
        }
        public void UpdateWorkers()
        {
            for (int i = 0; i < Departments.Count(); i++)
            {
                Departments[i].Workers = new ObservableCollection<Worker>
                (
                    DataService.GetWorkers(Departments[i].Id)
                );
            }
            Department dep = SelectedDepartment;
            SelectedDepartment = null;
            SelectedDepartment = dep;
        }
        public void UpdateOrders()
        {
            SelectedWorker.Orders = new ObservableCollection<Order>
            (
               DataService.GetOrders(SelectedWorker.Id)
            );

            Worker worker = SelectedWorker;
            SelectedWorker = null;
            SelectedWorker = worker;
        }
        #endregion
    }
}

