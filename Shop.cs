using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Shop
    {
        public Shop()
        {

        }

        public void ShowShop()
        {
            List<object> shop = new List<object>();
            HealthPotion hp = new HealthPotion("Health", true);

            shop.Add(hp);
        }

        public void BuyShop(ref Player player, ref HealthPotion hp, ref List<object> shop)
        {
            Console.WriteLine("Shop: ");
            for (int i = 0; i < shop.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", i, shop.);
            }

        }

        public void BuyHealthPotion(ref Player player, ref HealthPotion hp)
        {
            player.SetGold(-1);
            player.PickupItem(hp);
        }
    }
}
