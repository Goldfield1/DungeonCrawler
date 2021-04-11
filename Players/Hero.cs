using System;
using DungeonCrawler.Items;

namespace DungeonCrawler.Players {
    public abstract class Hero : Player {
        public string Name;
        
        public int Armor = 0;
        public int Weapon = 5;
        public int Damage = 1;
        
        public Room Room;
        
        public override int GetDamageLevel() {
            return Damage * Weapon;
        }

        public override void TakeDamage(int amount) {
            Armor -= amount;
            if (Armor < 0) {
                Health += Armor;
                Armor = 0;
            }
        }
    }
}