using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities;

namespace Toy.Entities.Concrete
{
   public class EducationalToy :IEntity
    {
        public int Id { get; set; }
        public int EducationalId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }

    }
}
