using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities;

namespace Toy.Entities.Concrete
{
   public class ScienceToy :IEntity
    {
        public int Id { get; set; }
        public int ScienceId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
    }
}
