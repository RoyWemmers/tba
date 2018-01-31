using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Actors
{
    class Rik : Actor
    {
        public Rik(string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {
            health = 10000;
            maxHealth = 10000;

        }

        public override void TakeHit(int damage)
        {
            health -= damage;
        }

        public void Greet()
        {
            string input;

            Console.WriteLine("You encounter Rik…");
            Console.WriteLine("Rik appears to be wearing an adidas tracksuit…");
            Console.WriteLine("Rik: “Hello broer, I’m Rik. I’ve lived in this forest for about 30 years.”");
            Console.WriteLine("Rik: “Glad to see someone else around, I’m a trader. I trade general goods; like potions, food, adidas tracksuits and steleptric!”");
            Console.WriteLine("Rik: “Do you want to know more about steleptric?”");
            Console.WriteLine("Enter y or n");
            do
            {
                input = Console.ReadLine();
            } while (input != "y" || input != "n");

            if (input == "y")
            {
                Console.Clear();
                Console.WriteLine("Rik: “So you want to know more about steleptric huh ?”");
                Console.WriteLine("Rik sits down on a stump and looks up…");
                Console.WriteLine("Rik: “Steleptric is the new way of transportation, its something special… for only 100G”");
            }

        }
    }
}
