using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkersDep.Models;
using WorkersDep.Services.DataBaseService;
using WorkersDep.Services.DelegateCommand;

namespace WorkersDep.ViewModels
{
    class DepartmentViewModel : ViewModel
    {
        DataBaseService DataService;

        private Department department;

        public Department Department
        {
            get => department;
            set
            {
                department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        public DelegateCommand Click_Save { get; private set; }
        public DelegateCommand Click_Delete { get; private set; }
        public DelegateCommand Click_Demote { get; private set; }
 
        public Action CloseAction { get; set; }

        public DepartmentViewModel(Action CloseAction)
        {
            DataService = new DataBaseService();
            Department = new Department();
            this.CloseAction = CloseAction;
            Click_Save = new DelegateCommand(AddDepartment, CanSaveDepartment);
            Click_Delete = new DelegateCommand(RemoveDepartment, CanRemoveDepartment);
            Click_Demote = new DelegateCommand(DemoteDepartment);

        }

        public DepartmentViewModel(int departmentId, Action CloseAction)
        {
            DataService = new DataBaseService();
            Department = DataService.GetDepartment(departmentId);

            this.CloseAction = CloseAction;
            Click_Save = new DelegateCommand(UpdateDepartment, CanSaveDepartment);
            Click_Delete = new DelegateCommand(RemoveDepartment,CanRemoveDepartment);
            Click_Demote = new DelegateCommand(DemoteDepartment);
        }


        private void DemoteDepartment(object param)
        {
            Department.Boss = null;
            Department.BossId = null;
            Department dep = Department;
            Department = null;
            Department = dep;
        }
        private void AddDepartment(object param)
        {
            DataService.CreateEntity(Department);
            CloseAction();
        }
        private void UpdateDepartment(object param)
        {
            DataService.UpdateDepartment(Department);
            CloseAction();
        }
        private bool CanSaveDepartment(object param)
        {
            if (string.IsNullOrWhiteSpace(Department.Name)) return false;
            if (string.IsNullOrEmpty(Department.Name)) return false;
            return true;
        }
        private void RemoveDepartment(object param)
        {
            DataService.UpdateDepartment(Department);
            DataService.RemoveEntity(Department);
            CloseAction();
        }
        private bool CanRemoveDepartment(object param)
        {
            return Department.Boss == null;
        }
    }
}
