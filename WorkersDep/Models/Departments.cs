using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkersDep.Models;

namespace WorkersDep.Models
{
    public partial class Department : IEntity
    {
        public Department() { }

        [Key]
        public int Id { get; set; }
        public int? BossId { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(BossId))]
        public virtual Worker Boss { get; set; }
        
        [InverseProperty("Department")]
        public virtual ICollection<Worker> Workers { get; set; }

        public override string ToString() 
        {
            return Name;
        }
    }
}
