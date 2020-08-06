using System;
using System.Collections.Generic;
using WorkersDep.Models;

namespace WorkersDep.Models
{
    public partial class Gender : IEntity
    {
        public int Id { get; set; }
        public string HumanGender { get; set; }

        public override string ToString()
        {
            return HumanGender;
        }
    }
}
