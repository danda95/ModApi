using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{
    public class Animal
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Species { get; set; }
        public int NumberOfLegs { get; set; }



        public Animal(int id, string name, string species, int numberOfLegs)
        {
            this.id = id;
            Name = name;
            Species = species;
            NumberOfLegs = numberOfLegs;
        }
    }
}
