using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class BloodDrake : Actor
    {
        public BloodDrake(string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {

        }

        public override void TakeHit(int damage)
        {
            health -= damage;
        }

        public void StartEncouter(ref Player player, ref Map map)
        { 
            Console.WriteLine("The Blood Drake Attacks!");
            do
            {
                Program.HealthUI("Blood Drake", health, maxHealth, stamina, maxStamina, 10);
                CastAbility(ref player);
                FightUI fui = new FightUI();
                health -= fui.ShowFightUI(ref player);
                Console.Clear();
            } while (health > 1);
            Console.WriteLine("The Blood Drake falls down from the sky!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Congrats! You've defeated the Blood Drake!");
            player.SetGold(10);
            player.SetStamina(-player.GetMaxStamina());
            Console.WriteLine("You get 10G loot!");
            
        }

        public void CastAbility(ref Player player)
        {
            Random rnd = new Random();

            switch (rnd.Next(1,3))
            {
                case 1:
                    player.SetStamina(Scare());
                    break;
                case 2:
                    player.SetHealth(Claw());
                    break;
                case 3:
                    player.SetHealth(ShootFireBall());
                    break;
            }
        }


        public int Scare()
        {
            Random rnd = new Random();

            int staminaLoss = rnd.Next(2, 10);

            Console.WriteLine();
            Console.WriteLine("The Blood Drake Flies really high in to the sky!");
            Console.WriteLine("After about five seconds the Blood Drake starts decending really fast!");
            Console.WriteLine("The Blood Drake near misses you!");
            Console.WriteLine("The Blood Drake scares you!");
            Console.WriteLine("Dealing {0} stamina loss!", staminaLoss);
            Console.WriteLine();

            return staminaLoss;
        }

        public int Claw()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 5);

            Console.WriteLine();
            Console.WriteLine("The Blood Drake claws you!");
            Console.WriteLine("Dealing {0} damage!", damage);
            Console.WriteLine();

            return damage;
        }

        public int ShootFireBall()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 10);

            Console.WriteLine();
            Console.WriteLine("The Blood Drake shoots a FireBall at you!");
            Console.WriteLine("Dealing {0} damage!", damage);
            Console.WriteLine();

            return damage;
        }
    }
}
