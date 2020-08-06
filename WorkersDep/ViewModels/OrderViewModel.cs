using System;
using System.Collections.Generic;
using System.Text;
using WorkersDep.Models;
using WorkersDep.Services.DataBaseService;
using WorkersDep.Services.DelegateCommand;

namespace WorkersDep.ViewModels
{
    class OrderViewModel : ViewModel
    {
        Action CloseAction { get; set; }
        DataBaseService DataService;

        private Order order;
        public Order Order
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public OrderViewModel(Action actionClose,Worker worker) 
        {
            CloseAction = actionClose;
            Order = new Order() { WorkerId = worker.Id };
            DataService = new DataBaseService();
            this.CloseAction = CloseAction;
            Click_Save = new DelegateCommand(AddOrder, CanSaveOrder);
            Click_Delete = new DelegateCommand(RemoveOrder, CanRemoveOrder);
        }
        public OrderViewModel(Action actionClose,int Id) 
        {
            CloseAction = actionClose;
            DataService = new DataBaseService();
            Order = DataService.GetOrder(Id);
            this.CloseAction = CloseAction;
            Click_Save = new DelegateCommand(UpdateOrder, CanSaveOrder);
            Click_Delete = new DelegateCommand(RemoveOrder);
        }

        public DelegateCommand Click_Save { get; private set; }
        public DelegateCommand Click_Delete { get; private set; }

        private void AddOrder(object param)
        {
            DataService.CreateEntity(Order);
            CloseAction();
        }
        private void UpdateOrder(object param)
        {
            DataService.UpdateOrder(Order);
            CloseAction();
        }
        private bool CanSaveOrder(object param)
        {
            if (string.IsNullOrWhiteSpace(Order.Name)) return false;
            if (string.IsNullOrEmpty(Order.Name)) return false;
            return true;
        }
        private bool CanRemoveOrder(object param)
        {
            return false;
        }
        private void RemoveOrder(object param)
        {
            DataService.RemoveEntity(Order);
            CloseAction();
        }
    }
}
