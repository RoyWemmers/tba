using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class MainRoad : Location
    {
        public MainRoad(string name)
            : base(name)
        {
             
        }
        public override void Description()
        {
            // Insert a nice description
            Console.WriteLine("You are on the Main Road");
        }

    }
}
