using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DungeonCrawler.Items;
using DungeonCrawler.Players;

namespace DungeonCrawler {
    public class DungeonParser {
        public static Dungeon MakeDungeon(Hero hero, string filename) {
            Dungeon dungeon = new Dungeon();
            
            string[] lines = System.IO.File.ReadAllLines(filename);
            
            dungeon.PointScaleFactor = Int32.Parse(lines[0]);
            foreach (string line in lines.Skip(1)) {
                string[] lineInfo = line.Split(' ');
                
                if (lineInfo[0] == "room:" || lineInfo[0] == "door:") {
                    Point topLeft = new Point(
                        Int32.Parse(lineInfo[1]), Int32.Parse(lineInfo[2]));
                    Point bottomRight = new Point(
                        Int32.Parse(lineInfo[3]), Int32.Parse(lineInfo[4]));    
                    
                    if (lineInfo[0] == "room:") {
                        dungeon.Size = Math.Max(Math.Max(bottomRight.X, bottomRight.Y), dungeon.Size);
                        
                        Room r = new Room(topLeft, bottomRight);    
                        dungeon.Rooms.Add(r);
                        
                    } else {
                        Room room1 = null;
                        Room room2 = null;
                        
                        // each door has two rooms
                        foreach (Room room in dungeon.Rooms) {
                            if (room.isInside(topLeft)) {
                                
                                room1 = room;
                            } else if (room.isInside(bottomRight)) {
                                room2 = room;
                            }
                        }
                        
                        Point doorPoint;
                        if (room1.isInside(topLeft) && room2.isInside(bottomRight)) {
                            room1.AddDoor(topLeft, room2);
                            room2.AddDoor(bottomRight, room1);
                        }
                    }
                    
                } else {
                    Point loc = new Point(Int32.Parse(lineInfo[1]), Int32.Parse(lineInfo[2]));
                    
                    foreach (Room room in dungeon.Rooms) {
                        
                        if (room.isInside(loc)) {
                            
                            
                            if (lineInfo[0] == "monster:") {
                                Monster monster;
                                if (lineInfo[3] == "O") {
                                    monster = new Orc();
                                } else {
                                    monster = new Goblin();  
                                }
                                
                                monster.SetDungeon(dungeon);
                                monster.Pos = loc;
                                room.AddMonster(monster);    
                                
                            } else if ((lineInfo[0] == "item:")) {
                                Item item;
                                if (lineInfo[3] == "A") {
                                    item = new Armor();
                                    ((Armor)item).Resistance = Int32.Parse(lineInfo[4]);
                                } else {
                                    item = new Weapon();
                                    ((Weapon) item).Damage = Int32.Parse(lineInfo[4]);
                                }

                                item.Pos = loc;
                                room.AddItem(item);   
                            }    
                        } 
                    }
                }
            }
            
            List<Point> posWrap = new List<Point>();
            int len = 0;
            foreach (var room in dungeon.Rooms) {
                for (int i = room.TopLeft.X; i < room.BottomRight.X; i++) {
                    for (int j = room.TopLeft.Y; j < room.BottomRight.Y; j++) {
                        var point = new Point(i, j);

                        bool bad = false;
                        foreach (Monster monster in room.Monsters) {
                            if (monster.Pos.X == point.X && monster.Pos.Y == point.Y) {
                                bad = true;       
                            }    
                        }

                        if (!bad) {
                            posWrap.Add(point);
                            len++;      
                        }
                    }    
                }
            }
            
            Random ran = new Random();
            Point pos = posWrap[ran.Next(0, len-1)];
            hero.SetDungeon(dungeon);
            hero.Pos = pos;
   
            foreach (Room room in dungeon.Rooms) {
                if (room.isInside(hero.Pos)) {
                    hero.Room = room;
                    break;
                }    
            }
            
            dungeon.Hero = hero;
            
            return dungeon;
        } 
    }
}