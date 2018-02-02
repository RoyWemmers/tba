using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class CastleBoss : Actor
    {
        public CastleBoss (string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {

        }

        public override void TakeHit(int damage)
        {
            health -= damage;
        }

        public void StartEncounter(ref Player player)
        {
            Console.WriteLine("As you enter the castle JanJaap-TheoBert at charges you!");
            do
            {
                Program.HealthUI("JanJaap-TheoBert", health, maxHealth, stamina, maxStamina, 10);
                CastAbility(ref player);
                FightUI fui = new FightUI();
                health -= fui.ShowFightUI(ref player);
                Console.Clear();
            } while (health > 1);
            Console.WriteLine("The Castle Boss is knocked down..");
            player.ResetStamina(ref player);
            Console.WriteLine("He falls to his knees, and dies.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Congrats! You've won!");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

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
                case 4:
                    player.SetHealth(Throw());
                    break;
            }
        }


        public int Hook()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 6);

            Console.WriteLine();
            Console.WriteLine("The Castle boss starts running at you and throws a left hook");
            Console.WriteLine("The hook connects perfectly, dealing {0} damage", damage);
            Console.WriteLine();

            return damage;
        }

        public int Backfist()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 10);

            Console.WriteLine();
            Console.WriteLine("Theobert throws a spinning backfist at you, hitting you flush on your jaw!");
            Console.WriteLine("This amazing move took {0} points from your health!", damage);
            Console.WriteLine();

            return damage;
        }

        public int AxeKick()
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
        public int Throw()
        {
            Random rnd = new Random();

            int damage = rnd.Next(5, 10);

            Console.WriteLine();
            Console.WriteLine("Theo picks up a large rock from the ground and throws it at you");
            Console.WriteLine("The rock smashes against your face");
            Console.WriteLine("Dealing {0} damage!", damage);
            Console.WriteLine();

            return damage;
        }
    }
}
