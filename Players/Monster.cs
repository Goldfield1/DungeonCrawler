using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonCrawler.Players {
    public abstract class Monster : Player {
        Point target = new Point(-1000, -1000);
        Point previousDoor = new Point(-1000, -1000);

        public int Damage;
        
        public override int GetDamageLevel() {
            return Damage;
        }

        public override void TakeDamage(int amount) {
            Health -= amount;
        }

        public void MakeAutonomousMove() {
            Room room = findRoom();

            Room heroRoom = Dungeon.Hero.findRoom();
            
            bool heroInNextRoom = false;

            if (room == heroRoom) {
                target = Dungeon.Hero.Pos.Copy();
                Console.WriteLine("");
            } else {
                foreach (KeyValuePair<Point, Room> pair in room.Doors)
                {
                    if (pair.Value == heroRoom)
                    {
                        heroInNextRoom = true;
                        target = pair.Key;
                        break;
                    }
                }
            }

            /* if (!heroInNextRoom) {
                if (target.X != -1000) {
                    
                }
                int numberOfDoors = room.Doors.Count;
                var random = new Random();
                if (numberOfDoors == 1)
                {
                    target = room.Doors[1];
                };
            } */

            if (Pos.Copy() == target)
            {
                if (heroRoom.isInside(new Point(target.X + 1, target.Y)))
                {
                    target = new Point(target.X + 1, target.Y);
                }
                else if (heroRoom.isInside(new Point(target.X, target.Y + 1)))
                {
                    target = new Point(target.X, target.Y + 1);
                }
                else if (heroRoom.isInside(new Point(target.X - 1, target.Y)))
                {
                    target = new Point(target.X - 1, target.Y);
                }
                else if (heroRoom.isInside(new Point(target.X, target.Y - 1)))
                {
                    target = new Point(target.X, target.Y - 1);
                }
            }

            if (target.X == -1000)
            {
                return;
            }

            Point oldPos = Pos;
            int distNorth = Math.Abs(target.X - Pos.X) + Math.Abs(target.Y - Pos.Y - 1);
            int distSouth = Math.Abs(target.X - Pos.X) + Math.Abs(target.Y - Pos.Y + 1);
            int distWest = Math.Abs(target.X - Pos.X - 1) + Math.Abs(target.Y - Pos.Y);
            int distEast = Math.Abs(target.X - Pos.X + 1) + Math.Abs(target.Y - Pos.Y);

            if (heroInNextRoom)
            {
                target = new Point(-1000, -1000);
            }

            int min = Math.Min(Math.Min(distNorth, distSouth), Math.Min(distEast, distWest));
            Direction dir;
            if (min == distNorth) {
                dir = Direction.SOUTH;
            } else if (min == distSouth) {
                dir = Direction.NORTH;    
            } else if (min == distWest) {
                dir = Direction.EAST;    
            } else {
                dir = Direction.WEST;   
            }
            TryMove(dir);
            previousDoor = target.Copy();

            if (Dungeon.Hero.Pos == Pos) {
                Dungeon.Hero.TakeDamage(GetDamageLevel());
                    
                Console.WriteLine("Hero health at {0}", Dungeon.Hero.Health); 
                if (!Dungeon.Hero.IsDead()) {
                    Pos = oldPos;
                } else {
                    Console.WriteLine("GAME OVER");
                }
            }
        }
    }
}