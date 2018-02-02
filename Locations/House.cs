using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class House : Location
    {
        public House(string name)
            : base(name)
        { 
            
        }

        public override void Description()
        {
            Console.WriteLine("You walk onto a small path, leading to a tiny house..");
            Console.WriteLine("You decide to walk towards the house");

        }
    }
}
