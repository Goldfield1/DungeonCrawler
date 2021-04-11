//using System;
//using System.Collections.Generic;
//using DungeonCrawler.Players;
//
//namespace DungeonCrawler {
//    public class DungeonGenerator {
//        private static int numberOfRooms;
//        
//        public static Dungeon MakeDungeon(Hero hero, int dungeonSize, int numberOfRooms) {
//            
//            
//            Dungeon dungeon = new Dungeon();
//             
//            Random ran = new Random();
//            // rooms are made first
//           
//            Room room;
//            Point point1 = new Point(ran.Next(0,3), ran.Next(0, 3));
//            Point point2 = new Point(ran.Next(point1.X + 3, point1.X + 10), ran.Next(point1.Y + 3, point1.Y + 10));
//            
//            room = new Room(point1, point2);
//            dungeon.Rooms.Add(room);
//             
//            
//            for (int i = 0; i < numberOfRooms; i++) {
//                List<(Point,Point)> validPos = new List<(Point, Point)>() {
//                    
//                };
//    
//                
//                
//                foreach (Room r in dungeon.Rooms) {
//                    // north
//                    if (r.TopLeft.X <= northBottomRight.X && r.BottomRight.X < northBottomRight.X && r.TopLeft.Y < northBottomRight.Y && r.BottomRight.Y > northBottomRight.Y) {
//                        northTopLeft.X = r.BottomRight.X;
//                    }   
//                    if (r.TopLeft.X < northBottomRight.X && r.BottomRight.X > northBottomRight.X && r.TopLeft.Y < northBottomRight.Y && r.BottomRight.Y > northBottomRight.Y) {
//                        northBottomRight.X = r.TopLeft.X;
//                    }
//
//                    if (r.TopLeft.X < northBottomRight.X && r.TopLeft.Y < northBottomRight.Y && r.BottomRight.Y < northBottomRight.Y) {
//                        northTopLeft.Y = r.BottomRight.Y;
//                    }    
//                }
//
//                Room newRoom = new Room(new Point(), new Point());    
//            }
//            
//            return dungeon;
//        }
//        
//        
//        
//        private static int AddRoom(Dungeon dungeon, Room room, int dungeonSize) {
//            Point northTopLeft = new Point(0, 0);
//            Point northBottomRight = new Point(room.TopLeft.Y, room.BottomRight.X);
//
//            Point eastTopLeft = new Point(room.BottomRight.X, 0); 
//            Point eastBottomRight = new Point(dungeonSize, room.BottomRight.Y); 
//
//            Point southTopLeft = new Point(room.TopLeft.X, room.BottomRight.Y);
//            Point southBottomRight = new Point(dungeonSize, dungeonSize); 
//
//            Point westTopLeft = new Point(0, room.TopLeft.Y);
//            Point westBottomRight = new Point(room.TopLeft.X, dungeonSize); 
//
//            foreach (Room r in dungeon.Rooms) {
//                // north
//                if (r.TopLeft.X <= northBottomRight.X && r.BottomRight.X < northBottomRight.X && r.TopLeft.Y < northBottomRight.Y && r.BottomRight.Y > northBottomRight.Y) {
//                    northTopLeft.X = r.BottomRight.X;
//                }   
//                if (r.TopLeft.X < northBottomRight.X && r.BottomRight.X > northBottomRight.X && r.TopLeft.Y < northBottomRight.Y && r.BottomRight.Y > northBottomRight.Y) {
//                    northBottomRight.X = r.TopLeft.X;
//                }
//
//                if (r.TopLeft.X < northBottomRight.X && r.TopLeft.Y < northBottomRight.Y && r.BottomRight.Y < northBottomRight.Y) {
//                    northTopLeft.Y = r.BottomRight.Y;
//                }    
//            }
//            Random ran = new Random();
//            Point point1 = new Point(ran.Next(northTopLeft.X, northBottomRight.X),
//                ran.Next(northTopLeft.Y, northBottomRight.Y));
//
//            DungeonGenerator.numberOfRooms--;
//            
//            if (DungeonGenerator.numberOfRooms == 0) {
//                return 0;
//            } else {
//                return AddRoom(dungeon, newRoom, dungeonSize);
//            }
//        }
//
//        private static void AddAdjacentRoom(Dungeon dungeon, Room room, int dungeonSize) {
//            Point northTopLeft = new Point(0, 0);
//            Point northBottomRight = new Point(dungeonSize, room.TopLeft.Y);
//
//            Point eastTopLeft = new Point(room.BottomRight.X, 0); 
//            Point eastBottomRight = new Point(dungeonSize, dungeonSize); 
//
//            Point southTopLeft = new Point(0, room.BottomRight.Y);
//            Point southBottomRight = new Point(dungeonSize, dungeonSize); 
//
//            Point westTopLeft = new Point(0, 0);
//            Point westBottomRight = new Point(room.TopLeft.X, dungeonSize);   
//            
//            List<(Point, Point)> posWrap = new List<(Point, Point)>() {
//                (new Point(0, 0), new Point(dungeonSize, room.TopLeft.Y)),
//                (new Point(room.BottomRight.X, 0), new Point(dungeonSize, dungeonSize)),
//                (new Point(0, room.BottomRight.Y), new Point(dungeonSize, dungeonSize)),
//                (new Point(0, 0), new Point(room.TopLeft.X, dungeonSize))
//            };
//
//            foreach (Room r in dungeon.Rooms) {
//            }
//        }
//
//        private static List<(Point, Point)> IsInside(Point topLeft, Point bottomRight, Room room, Room newRoom) {
//            List<(Point, Point)> list = new List<(Point, Point)>();
//            
//            // box is left of the room
//            if (bottomRight.X <= room.BottomRight.X) {
//                if (newRoom.BottomRight.X <= room.TopLeft.X) {
//                    if (newRoom.TopLeft.Y >= room.BottomRight.Y) {
//                        list.Add();
//                    }                    
//                } else if (newRoom.TopLeft.X <= room.TopLeft.X) {
//                    
//                }
//            }
//
//
//            return list;
//        }
//        
//    }
//}