using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TextAdventureCS
{
    class Rik : Actor
    {
        public Rik(string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {

        }

        public override void TakeHit(int damage)
        {
            health -= damage;
        }

        public void GreetRikOutside()
        {
            int sleep = 2000;
            Console.WriteLine("You encounter Rik…");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik appears to be wearing an adidas tracksuit…");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik: “Hello broer, I’m Rik. I’ve lived in this forest for about 30 years.”");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik: “Glad to see someone else around, I’m a trader. I trade general goods; like potions, food, adidas tracksuits and steleptric!”");
            Thread.Sleep(sleep);
            TellAboutSteleptric();
        }

        public void GreetRikInside()
        {
            int sleep = 2000;
            Console.WriteLine("You walk inside…");
            Thread.Sleep(sleep);
            Console.WriteLine("Someone pulls on your shoulder!");
            Thread.Sleep(sleep);
            Console.WriteLine("You turn around...");
            Thread.Sleep(sleep);
            Console.WriteLine("You encounter Rik…");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik appears to be wearing an adidas tracksuit…");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik: “Hello broer, I’m Rik. I’ve lived in this Rune for about 30 years.”");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik: “What are you doing here, in my house? ");
            Console.WriteLine();

            Console.WriteLine("Reply:");
            Console.WriteLine("1) “I’m sorry!”");
            Console.WriteLine("2) “I saw a creature inside, so decided to have a look”");

            string input;
            do
            {
                input = Console.ReadLine();
            } while (input != "1" && input != "2");

            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("“I’m sorry!”");
            } else
            {
                Console.Clear();
                Console.WriteLine("“I saw a creature inside, so decided to have a look”");
            }

            Thread.Sleep(sleep);
            Console.WriteLine("Rik: “Alright... That creature was my pet, it’s my Nelus. It’s a special kind of dwarf, it cleans , my house all day long… It’s amazing!”");
            Thread.Sleep(sleep);
            Console.WriteLine("Rik: “I’m a trader. I trade general goods; like potions, food, adidas tracksuits and steleptric!”");
            Thread.Sleep(sleep);

            TellAboutSteleptric();
        }

        public void EncounterRik()
        {
            int sleep = 1000;
            string input;

            Console.WriteLine("In the process of walking to the top of the hill you see a Small old Rune.");
            Thread.Sleep(sleep);
            Console.WriteLine("As you approach the entry you are shocked to see a pair of glinstering red eyes stare at you.");
            Thread.Sleep(sleep);
            Console.WriteLine("As you get closer to the entry the creature screeshes and runs off into the ruin..");
            Thread.Sleep(sleep);

            do
            {
                Console.WriteLine("Do you want to follow the creature into the ruin? (y/n)");
                input = Console.ReadLine();
                Console.Clear();
            } while (input != "y" && input != "n");

            if (input == "n")
            {
                GreetRikOutside();
            } else
            {
                GreetRikInside();
            }
            

        }

        public void TellAboutSteleptric()
        {
            int sleep = 2000;
            string input;
            Console.WriteLine("Rik: “Do you want to know more about steleptric?” (y/n)?");
            do
            {
                input = Console.ReadLine();
            } while (input != "y" && input != "n");

            if (input == "y")
            {
                Console.Clear();
                Console.WriteLine("Rik: “So you want to know more about steleptric huh ?”");
                Thread.Sleep(sleep);
                Console.WriteLine("Rik sits down on a stump and looks up…");
                Thread.Sleep(sleep);
                Console.WriteLine("Rik: “Steleptric is the new way of transportation, its something special… for only 100G”");
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Rik gives you a slobbery wooden whistle…");
                Thread.Sleep(sleep);
                Console.WriteLine("Rik: “Blow this whistle if you ever want to buy anything from me!”");
                Thread.Sleep(sleep);
                Console.WriteLine("Rik spits on you and runs away!");
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
                Console.ReadLine();
            }
        }

        public void ShowShop()
        {
            List<object> shop = new List<object>();

            
        }
    }
}
