using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Actors
{
    class BloodDrake : Actor
    {
        public BloodDrake(string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {
            health = 50;
        }

        public override void TakeHit(int damage)
        {
            health -= damage;
        }

        public void StartEncouter(ref Player player)
        {
            Console.WriteLine("The Blood Drake Attacks!");
            do
            {
                CastAbility(ref player);
            } while (health > 1);
            Console.WriteLine("The Blood Drake falls down from the sky!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Congrats! You've defeated the Blood Drake!");
            Console.WriteLine("Loot: 10G, Sword, Pouch of Goods");
        }

        public void CastAbility(ref Player player)
        {
            Random rnd = new Random();

            switch (rnd.Next(1,3))
            {
                case 1:
                    player.SetHealth(Scare());
                    break;
                case 2:
                    Claw();
                    break;
                case 3:
                    ShootFireBall();
                    break;
            }
        }


        public int Scare()
        {
            Random rnd = new Random();

            int staminaLoss = rnd.Next(2, 10);

            Console.WriteLine("The Blood Drake Flies really high in to the sky!");
            Console.WriteLine("After about five seconds the Blood Drake starts decending really fast!");
            Console.WriteLine("The Blood Drake near misses you!");
            Console.WriteLine("The Blood Drake scares you!");
            Console.WriteLine("Dealing {0} stamina loss!", staminaLoss);

            return staminaLoss;
        }

        public int Claw()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 5);

            Console.WriteLine("The Blood Drake claws you!");
            Console.WriteLine("Dealing {0} damage!", damage);

            return damage;
        }

        public int ShootFireBall()
        {
            Random rnd = new Random();

            int damage = rnd.Next(2, 10);

            Console.WriteLine("The Blood Drake shoots a FireBall at you!");
            Console.WriteLine("Dealing {0} damage!", damage);

            return damage;
        }
    }
}
