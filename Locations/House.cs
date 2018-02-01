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
            // Add items here
           // Diamond dia = new Diamond("Brass Knuckles", true);
           // items.Add(dia.GetName(), dia);
            // If there is an enemy, set enemy to true
           // hasEnemy = true;
        }

        public override void Description()
        {
            // Insert a nice description
            Console.WriteLine("You are standing in front of the door");
        }
    }
}
