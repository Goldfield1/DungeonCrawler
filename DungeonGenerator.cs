using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawler.Items;
using DungeonCrawler.Players;

namespace DungeonCrawler
{
    class DungeonGenerator
    {
        private static readonly Random ran = new Random();

        private static int randomSide() {
            return ran.Next(1, 4);
        }

        private static Room makeRoom(Room room) {

            int roomLength = room.BottomRight.X - room.TopLeft.X;
            int roomHeight = room.BottomRight.Y - room.TopLeft.Y;

            Room newRoom = new Room(new Point(), new Point());
            int side = randomSide();
            switch (side) {
                // left
                case 1:
                    newRoom.BottomRight.X = room.TopLeft.X;
                    newRoom.TopLeft.Y = room.TopLeft.Y + ran.Next(0, roomHeight - 3);
                    newRoom.TopLeft.X = room.TopLeft.X - ran.Next(3, 20);
                    newRoom.BottomRight.Y = newRoom.TopLeft.Y + ran.Next(3, 20);
                    break;
                // top
                case 2:
                    newRoom.BottomRight.Y = room.TopLeft.Y;
                    newRoom.TopLeft.X = room.TopLeft.X + ran.Next(0, roomLength - 3);
                    newRoom.TopLeft.Y = room.TopLeft.Y - ran.Next(3, 20);
                    newRoom.BottomRight.X = newRoom.TopLeft.X + ran.Next(3, 20);
                    break;
                // right
                case 3:
                    newRoom.TopLeft.X = room.BottomRight.X;

                    newRoom.TopLeft.Y = room.TopLeft.Y + ran.Next(0, roomHeight - 3);

                    newRoom.BottomRight.Y = newRoom.TopLeft.Y + ran.Next(3, 20);
                    newRoom.BottomRight.X = room.BottomRight.X + ran.Next(3, 20);

                    //newRoom.TopLeft.Y = newRoom.BottomRight.Y - ran.Next(3, 20);
                    break;
                // bottom
                case 4:
                    newRoom.TopLeft.Y = room.BottomRight.Y;
                    newRoom.TopLeft.X = room.TopLeft.X + ran.Next(0, roomLength - 3);

                    newRoom.BottomRight.X = newRoom.TopLeft.X + ran.Next(3, 20);
                    newRoom.BottomRight.Y = newRoom.TopLeft.Y + ran.Next(3, 8);
                    break;
            }   
            return newRoom;
        }

        public static Dungeon GenerateDungeon(Hero hero)
        {
            Random ran = new Random();

            Dungeon dungeon = new Dungeon();

            Room room = new Room(new Point(0, 0), new Point(ran.Next(3,10), ran.Next(3,20)));
            dungeon.Rooms.Add(room);

            Room newRoom = room;

            for (int j = 0; j < 2; j++) {
                for (int i = 0; i < 2000; i++) {
                    newRoom = makeRoom(room);
                    bool overlap = false;
                    foreach (Room r in dungeon.Rooms) {
                        if (r.isInside(newRoom.TopLeft) || r.isInside(newRoom.BottomRight) || r.isInside(new Point(newRoom.TopLeft.X, newRoom.BottomRight.Y)) || r.isInside(new Point(newRoom.TopLeft.Y, newRoom.BottomRight.X))) {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap) {
                        continue;
                    }
                    if (newRoom.TopLeft.X < 0 || newRoom.TopLeft.X > 29 || newRoom.TopLeft.Y < 0 || newRoom.TopLeft.Y > 29 || newRoom.BottomRight.X > 29 || newRoom.BottomRight.Y > 29) {
                        //Console.WriteLine(",,");
                    }
                    else {
                        dungeon.Rooms.Add(newRoom);
                        room = newRoom;
                        break;
                    }
                }
                //Console.WriteLine(newRoom.TopLeft);
                //Console.WriteLine(newRoom.BottomRight);
                //dungeon.Rooms.Add(newRoom);
                //room = newRoom;
            }

            for (int j = 0; j < dungeon.Rooms.Count; j++) {
                room = dungeon.Rooms[j];
                for (int i = 0; i < 2000; i++) {
                    newRoom = makeRoom(room);
                    bool overlap = false;
                    foreach (Room r in dungeon.Rooms) {
                        if (r.isInside(newRoom.TopLeft) || r.isInside(newRoom.BottomRight) || r.isInside(new Point(newRoom.TopLeft.X, newRoom.BottomRight.Y)) || r.isInside(new Point(newRoom.TopLeft.Y, newRoom.BottomRight.X))) {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap) {
                        continue;
                    }
                    if (newRoom.TopLeft.X < 0 || newRoom.TopLeft.X > 29 || newRoom.TopLeft.Y < 0 || newRoom.TopLeft.Y > 29 || newRoom.BottomRight.X > 29 || newRoom.BottomRight.Y > 29) {
                        //Console.WriteLine(",,");
                    }
                    else {
                        dungeon.Rooms.Add(newRoom);
                        room = newRoom;
                        break;
                    }
                }
            }


            for (int i = 0; i < 5; i++)
            {
                foreach(Room r in dungeon.Rooms)
                {
                
                }   
            }



            return dungeon;
        }
    }
}
