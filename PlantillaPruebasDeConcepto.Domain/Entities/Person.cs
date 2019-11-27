using System;
using System.Collections.Generic;
using System.Text;

namespace PlantillaPruebasDeConcepto.Domain.Entities
{
    public class Person: EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
