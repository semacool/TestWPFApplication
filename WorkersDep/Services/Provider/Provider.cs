using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WorkersDep.Models;
using WorkersDep.ViewModels;
using WorkersDep.Views;

namespace WorkersDep.Services.Provider
{
    class Provider
    {
        static public void OpenWindow(object param)
        {
            Window window = null;

            string type = param.GetType().Name;
            switch (type) 
            {
                case "String":
                    window = new DepartmentView();
                    break;
                case "Department":
                    window = new WorkerView(param as Department);
                    break;
                case "Worker":
                    window = new OrderView(param as Worker);
                    break;
            }

             window.ShowDialog();
        }

        static public void OpenWindowParam(object param)
        {
            Window window = null;
            string typeParam = param.GetType().Name;

            switch (typeParam)
            {
                case "Department":
                    window = new DepartmentView(param as Department);
                    break;
                case "Worker":
                    window = new WorkerView(param as Worker);
                    break;
                case "Order":
                    window = new OrderView(param as Order);
                    break;
            }

            window.ShowDialog();
        }


    }
}

