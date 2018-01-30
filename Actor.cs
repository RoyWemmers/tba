using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    abstract class Actor
    {
        protected string name;
        protected int maxHealth;
        protected int health;
        protected int stamina;
        protected int maxStamina;
        
        public Actor( string name, int maxHealth, int maxStamina )
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.maxStamina = maxStamina;
            this.stamina = maxStamina;
        }

        public abstract void TakeHit(int damage);

        public void UseStamina(int usedStamina, ref Player player)
        {
            player.stamina -= usedStamina;
        }

        public string GetName()
        {
            return name;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetMaxStamina()
        {
            return maxStamina;
        }

        public int GetStamina()
        {
            return stamina;
        }


    }
}
