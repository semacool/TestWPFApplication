using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkersDep.Models;

namespace WorkersDep.Models
{
    public partial class Worker : IEntity
    {
        public Worker() { }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthday { get; set; }

        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }


        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [InverseProperty("Boss")]
        public virtual Department BossOfDepartment { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Middlename}";
        }
    }
}
