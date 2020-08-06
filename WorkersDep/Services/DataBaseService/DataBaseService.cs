using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersDep.DataBase;
using WorkersDep.Models;

namespace WorkersDep.Services.DataBaseService
{
    class DataBaseService
    {
        
        public void CreateEntity<T>(T Entity) where T : class
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                CompanyDBContext.Set<T>().Add(Entity);
                CompanyDBContext.SaveChanges();
            }
        }
        public void RemoveEntity<T>(T Entity) where T : class
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                CompanyDBContext.Set<T>().Remove(Entity);
                CompanyDBContext.SaveChanges();
            }
        }

        public void UpdateDepartment(Department Entity)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                var OldEntity = CompanyDBContext.Set<Department>().Find(Entity.Id);

                OldEntity.Name = Entity.Name;

                if(Entity.Boss != null)
                    OldEntity.BossId = Entity.Boss.Id;
                else 
                    OldEntity.BossId = null;

                CompanyDBContext.SaveChanges();
            }
        }
        public void UpdateWorker(Worker Entity)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                var OldEntity = CompanyDBContext.Set<Worker>().Find(Entity.Id);
                OldEntity.Name = Entity.Name;
                OldEntity.Surname = Entity.Surname;
                OldEntity.Middlename = Entity.Middlename;
                OldEntity.DepartmentId = Entity.Department.Id;
                OldEntity.Birthday = Entity.Birthday;
                OldEntity.GenderId = Entity.Gender.Id;
                CompanyDBContext.SaveChanges();
            }
        }
        public void UpdateOrder(Order Entity)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                var OldEntity = CompanyDBContext.Set<Order>().Find(Entity.Id);
                OldEntity.Name = Entity.Name;
                CompanyDBContext.SaveChanges();
            }
        }


        public ICollection<Department> GetDepartments()
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                List<Department> departments = CompanyDBContext.Set<Department>().ToList();

                for (int i = 0; i < departments.Count(); i++)
                {
                    Department dep = departments[i];
                    dep.Workers = GetWorkers(dep.Id);
                    if(dep.BossId.HasValue)
                        dep.Boss = GetWorker(dep.BossId.Value);
                }
                return departments;
            }
        }
        public ICollection<Worker> GetWorkers(int depId)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                List<Worker> workers = CompanyDBContext.Set<Worker>().Where(w=>w.DepartmentId == depId).ToList();

                for (int i = 0; i < workers.Count(); i++)
                {
                    Worker worker = workers[i];
                    worker.Gender = GetGender(worker.GenderId);
                    worker.Orders = GetOrders(worker.Id);            
                }
                return workers;
            }
        }
        public ICollection<Order> GetOrders(int workId)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                List<Order> orders = CompanyDBContext.Set<Order>().Where(o => o.WorkerId == workId).ToList();
                for (int i = 0; i < orders.Count(); i++)
                {
                    Order order = orders[i];
                }
                return orders;
            }
        }
        public ICollection<Gender> GetGenders()
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                List<Gender> genders = CompanyDBContext.Set<Gender>().ToList();

                return genders;
            }
        }


        public Department GetDepartment(int Id)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                Department department = CompanyDBContext.Set<Department>().ToList().FirstOrDefault(d=> d.Id == Id);

                department.Workers = GetWorkers(department.Id);

                if(department.BossId.HasValue)
                    department.Boss = department.Workers.FirstOrDefault(w=>w.Id == department.BossId);

                return department;
            }
        }
        public Worker GetWorker(int Id)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                Worker worker = CompanyDBContext.Set<Worker>().FirstOrDefault(w=>w.Id == Id);
                worker.BossOfDepartment = CompanyDBContext.Set<Department>().FirstOrDefault(d => d.BossId == worker.Id);
                return worker;
            }
        }
        public Order GetOrder(int Id)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                Order order = CompanyDBContext.Set<Order>().FirstOrDefault(o => o.Id == Id);
                return order;
            }
        }
        public Gender GetGender(int IdGender)
        {
            using (var CompanyDBContext = new CompanyDBContext())
            {
                Gender gender = CompanyDBContext.Set<Gender>().FirstOrDefault(g=>g.Id == IdGender);

                return gender;
            }
        }
    }
}
