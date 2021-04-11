using System.Drawing;

namespace DungeonCrawler.Players {
    public class Goblin : Monster {
        public Goblin() {
            Regen = 2;
            Damage = 5;
            Color = Color.DimGray;
        }
    }
}