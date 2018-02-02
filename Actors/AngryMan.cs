using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class AngryMan : Actor
    {
        public AngryMan(string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {

        }

        public override void TakeHit(int damage)
        {
            health -= damage;
        }

        public void StartEncounter(ref Player player)
        {
            Console.WriteLine("The Angry Man Attacks!");
            do
            {
                Program.HealthUI("Angry Man", health, maxHealth, stamina, maxStamina, 10);
                CastAbility(ref player);
                FightUI fui = new FightUI();
                health -= fui.ShowFightUI(ref player);
                Console.Clear();
            } while (health > 1);
            Console.WriteLine("The angry man is knocked down..");
            player.ResetStamina(ref player);
            Console.WriteLine("As his head bounces against the floor he stops breathing.. ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Congrats! You've killed an innocent man in his own house!");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

            Console.WriteLine("After you took the man's money you decide to look search his house for usefull stuff.");
            player.SetGold(20);
            Console.WriteLine("As you scavenge around the house you find a bag of gold containing 20 gold coins!");
            
        }

        public void CastAbility(ref Player player)
        {
            Random rnd = new Random();

            switch (rnd.Next(1, 3))
            {
                case 1:
                    player.SetStamina(Hook());
                    break;
                case 2:
                    player.SetHealth(Backfist());
                    break;
                case 3:
                    player.SetHealth(AxeKick());
                    break;
            }
        }


        public int Hook()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 6);

            Console.WriteLine();
            Console.WriteLine("The Angry man starts bum-rushing you and throws a left hook");
            Console.WriteLine("The hook connects perfectly, dealing {0} damage", damage);
            Console.WriteLine();

            return damage;
        }

        public int Backfist()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 10);

            Console.WriteLine();
            Console.WriteLine("The angry man throws a spinning backfist at you, hitting you flush on your jaw!");
            Console.WriteLine("This amazing move took {0} points from your health!", damage);
            Console.WriteLine();

            return damage;
        }

        public int AxeKick ()
        {
            Random rnd = new Random();

            int damage = rnd.Next(5, 10);

            Console.WriteLine();
            Console.WriteLine("The Angry man throws an axek-kick at you");
            Console.WriteLine("His boot cleanly strikes across your face");
            Console.WriteLine("Dealing {0} damage!", damage);
            Console.WriteLine();

            return damage;
        }
    }
}
