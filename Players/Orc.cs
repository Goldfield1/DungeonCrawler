using System.Drawing;

namespace DungeonCrawler.Players {
    public class Orc : Monster {
        public Orc() {
            Regen = 10;
            Damage = 20;
            Color = Color.Green;
        }
    }
}