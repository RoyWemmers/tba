using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TextAdventureCS
{
    class Player : Actor
    {
        private Dictionary<string, Objects> inventory;
        protected float gold;

        public Player(string name, int maxHealth, int maxStamina)
            : base(name, maxHealth, maxStamina)
        {
            inventory = new Dictionary<string, Objects>();
            gold = 1;
        }

        public void DropItem(string itemName)
        {
            if (HasObject(itemName))
            {
                inventory.Remove(itemName);
                Console.WriteLine("{0} is removed from your inventory",itemName);
                ShowInventory();
                Console.WriteLine("Press a key to continue..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your inventory does not contain an item");
                Console.WriteLine("with the name {0}. Please try again.", itemName);
                Console.WriteLine("Press a key to continue..");
                Console.ReadKey();
            }
        }

        public void PickupItem(Objects obj)
        {
            // Add an if-statement here when you want to have a maximum number of items
            if(HasObject(obj.GetName()))
            {
                Console.WriteLine("You already carry the maximum amount of this item");
                gold += 1;
            } else
            {
                inventory.Add(obj.GetName(), obj);
                obj.SetIsAcquirable(false);
            }
           
        }

        public void ShowInventory()
        {
            Console.WriteLine("There are {0} item(s) in your inventory.", (int)inventory.Count());
            if (inventory.Count() > 0)
            {
                Console.WriteLine("These are:");
                foreach (var item in inventory)
                {
                    Console.WriteLine(item.Value);
                    
                }

            }

        }

        public bool HasObject(string name)
        {
            if (inventory.ContainsKey(name))
                return true;
            else
                return false;
        }

        public override void TakeHit( int damage )
        {
            if (health - damage < 0)
            {
                Console.Clear();
                Console.WriteLine("You took too much damage. You fall to the ground.");
                Console.WriteLine("As you move towards the light, the last thing going through");
                Console.WriteLine("your mind is: 'This was a great adventure. Too bad it had");
                Console.WriteLine("to end like this.' And then it is all over...");
                Console.WriteLine("Press a key to continu...");
                Console.ReadKey();
            }
            else
            {
                health -= damage;
                Console.Clear();
                Console.WriteLine("You took {0} points of damage.", damage);
                Console.WriteLine("You now have {0} HP left.", health);

                if (health < (maxHealth >> 2))
                {
                    Console.WriteLine("You took some serious hits and you are bleeding.");
                    Console.WriteLine("You start to feel weak and desperately need some");
                    Console.WriteLine("medical attention.");
                }
                else if (health < (maxHealth >> 1))
                {
                    Console.WriteLine("You took some hits. You have some scratches and some cuts.");
                    Console.WriteLine("Your body starts to ache and you have to be careful.");
                }
                else if (health < (maxHealth - (maxHealth >> 2)))
                {
                    Console.WriteLine("You have a few scratches, nothing to worry about yet.");
                }
                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
            }
        }

        public int BasicAttack(ref Player player, int bonusDamage)
        {
            if(player.GetStamina() < 0)
            {
                Console.WriteLine("You don't have enough mana!");
            } else
            {
                int damage = 4 + bonusDamage;

                player.SetStamina(2);

                return damage;
            }
            return 0;
        }

        public void ClimbBridge(ref Player player)
        {
            Random rnd = new Random();

            int fall = rnd.Next(1, 100);

            if (fall >= 80)
            {
                Console.WriteLine("Noo! You fell in to the river!");
                Console.WriteLine("You take 20 damage for falling in to the river!");
                Console.WriteLine("Luckily you could swim to the shore on the other side!");
                player.TakeHit(20);
            } else
            {
                Console.WriteLine("The side of the Bridge is really slippery!");
                Console.WriteLine("Luckly you made it without a scratch!");
            }

        }

        public float GetGold()
        {
            return gold;
        }

        public void SetGold(int addGold)
        {
            gold += addGold;
        }

        public void DelItemInvenyory(string name)
        {
            inventory.Remove(name);
        }
    }
}
