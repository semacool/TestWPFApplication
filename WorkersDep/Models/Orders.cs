using System;
using System.Collections.Generic;
using WorkersDep.Models;

namespace WorkersDep.Models
{
    public partial class Order : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
