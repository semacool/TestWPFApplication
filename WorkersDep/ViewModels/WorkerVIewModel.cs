using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkersDep.Models;
using WorkersDep.Services.DataBaseService;
using WorkersDep.Services.DelegateCommand;

namespace WorkersDep.ViewModels
{
    class WorkerVIewModel : ViewModel
    {
        Action ActionClose;
        DataBaseService DataService;

        public DelegateCommand Click_Save { get; private set; }
        public DelegateCommand Click_Delete { get; private set; }
        public bool WorkerNotBoss { get; set; }

        private Worker worker;
        private Gender selectedGender;
        private Department selectedDepartment;
        ObservableCollection<Gender> genders;
        ObservableCollection<Department> departments;

        public Worker Worker 
        { 
            get => worker;
            set
            { 
                worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }
        public ObservableCollection<Gender> Genders 
        {
            get => genders;
            set 
            {
                genders = value;
                OnPropertyChanged(nameof(Genders));
            }
        }
        public Gender SelectedGender
        {
            get => selectedGender;
            set
            {
                selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
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
        public ObservableCollection<Department> Departments
        {
            get => departments;
            set
            {
                departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }


        public WorkerVIewModel(Action action,Department department)
        {
            InitWorker(action);
            Worker = new Worker() {DepartmentId = department.Id};
            SelectedDepartment = Departments.FirstOrDefault(d => d.Id == Worker.DepartmentId);
            Click_Save = new DelegateCommand(AddWorker, CanSaveWorker);
            Click_Delete = new DelegateCommand(RemoveWorker,CanRemoveWorker);
        }
        public WorkerVIewModel(Action action, int Id)
        {
            InitWorker(action);
            Worker = DataService.GetWorker(Id);
            if (Worker.BossOfDepartment != null) WorkerNotBoss = false;
            else WorkerNotBoss = true;  
            SelectedGender = Genders.FirstOrDefault(g=> g.Id == Worker.GenderId);
            SelectedDepartment = Departments.FirstOrDefault(d => d.Id == Worker.DepartmentId);
            Click_Save = new DelegateCommand(UpdateWorker, CanSaveWorker);
            Click_Delete = new DelegateCommand(RemoveWorker);
        }

        private void InitWorker(Action action) 
        {
            ActionClose = action;
            DataService = new DataBaseService();
            Departments = new ObservableCollection<Department>(DataService.GetDepartments());
            Genders = new ObservableCollection<Gender>(DataService.GetGenders());
        }

        private void UpdateWorker(object param) 
        {
            Worker.Gender = SelectedGender;
            Worker.Department = SelectedDepartment;
            DataService.UpdateWorker(Worker);
            ActionClose();
        }

        private void RemoveWorker(object param)
        {
            DataService.RemoveEntity(Worker);
            ActionClose();
        }

        private void AddWorker(object param)
        {
            Worker.GenderId = SelectedGender.Id;
            Worker.DepartmentId = SelectedDepartment.Id;
            DataService.CreateEntity(Worker);
            ActionClose();
        }

        private bool CanRemoveWorker(object param) 
        {
            return false;
        }

        private bool CanSaveWorker(object param)
        {
            if (SelectedDepartment == null) return false;
            if (SelectedGender == null) return false;
            if (Worker.Birthday == null) return false;

            return true;

        }
    }

}
