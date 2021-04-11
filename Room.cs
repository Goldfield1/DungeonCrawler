using System.Collections.Generic;
using DungeonCrawler.Items;
using DungeonCrawler.Players;

namespace DungeonCrawler {
    public class Room {
        public Dictionary<Point, Room> Doors;
        public List<Monster> Monsters;
        public List<Item> Items;
        
        public Point TopLeft;
        public Point BottomRight;
        
        public Room(Point topLeft, Point bottomRight) {
            Doors = new Dictionary<Point, Room>();
            
            Monsters = new List<Monster>();
            Items = new List<Item>();
            
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
        
        private void removePlayer(Player player) {
            
        }

        public void AddItem(Item item) {
            Items.Add(item);
        }
        
        public void AddMonster(Monster monster) {
            Monsters.Add(monster);
        }
        
        public void AddDoor(Point point, Room room) {
            Doors.Add(point, room);
        }
        
        public bool isInside(Point point) {
            return (TopLeft.X <= point.X && point.X < BottomRight.X && TopLeft.Y <= point.Y && point.Y < BottomRight.Y) ||
                (TopLeft.X < point.X && point.X <= BottomRight.X && TopLeft.Y < point.Y && point.Y <= BottomRight.Y);
        }
    }
}