using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Items
{
    class HealthPotion : Objects
    {
        public HealthPotion(string name, bool acquirable)
            : base(name, acquirable)
        {
        }

        override protected void Description()
        {
            Console.WriteLine("You have a Health Potion in your hand");
        }

        public void UsePotion()
        {

        }
    }
}
