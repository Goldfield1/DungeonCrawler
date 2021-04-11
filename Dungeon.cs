using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DungeonCrawler.Items;
using DungeonCrawler.Players;

namespace DungeonCrawler {
    public class Dungeon {
        public List<Room> Rooms;
        public int PointScaleFactor;
        public int Size;
        
        public Hero Hero;
        
        public Dungeon() {
            PointScaleFactor = 20;
            
            Rooms = new List<Room>();
        }

        public Item Loot(Point pos) {
            foreach (Room room in Rooms) {
                foreach (Item item in room.Items) {
                    if (item.Pos == pos) {
                        room.Items.Remove(item);

                        if (item.GetType() == typeof(Armor)) {
                            var armor = ((Armor) item).Resistance;
                            if (Hero.Armor < armor) {
                                Console.WriteLine("Hero picks up armor with {0} resistance", armor);
                                Hero.Armor = armor;
                            }
                        } else {
                            var weapon = ((Weapon) item).Damage;
                            if (Hero.Weapon < weapon) {
                                Console.WriteLine("Hero picks up weapon with {0} damage", weapon);
                                Hero.Weapon = weapon;
                            }    
                        }
                        return item;
                    }    
                }  
            }
            return null;
        }
        
        public void OnKeyDown(Keys e) {
            bool moved = false;
            if (Hero.HasTurn) {
                switch (e) {
                    case Keys.Up:
                         moved = Hero.TryMove(Direction.NORTH);
                        break;
                    case Keys.Down:
                        moved = Hero.TryMove(Direction.SOUTH);
                        break;
                    case Keys.Left:
                        moved = Hero.TryMove(Direction.WEST);
                        break;
                    case Keys.Right:
                        moved = Hero.TryMove(Direction.EAST);
                        break;
                }
                if (moved) {
                    Loot(Hero.Pos);
                    Hero.HasTurn = false;
                    
                    foreach (Room room in Rooms) {
                        
                        for (int i = room.Monsters.Count - 1; i > -1; i--) {
                            
                            Monster monster = room.Monsters[i];

                            if (monster.IsDead()) {
                                room.Monsters.RemoveAt(i);
                                continue;
                            }
                            
                            if (monster.HasTurn) {
                                monster.MakeAutonomousMove(); 
                                monster.HasTurn = false;
                            }
                            
                            
                        }        
                    }
                    
                    Hero.Regenerate();
                    foreach (Room room in Rooms) {
                        foreach (Monster monster in room.Monsters) {
                            monster.Regenerate();
                            monster.HasTurn = true;
                        }    
                    }
                    
                    Hero.HasTurn = true;
                }
            }
        }
                
    }
}