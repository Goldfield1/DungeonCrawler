using System;
using System.Drawing;

namespace DungeonCrawler.Players {
    public abstract class Player {
        
        public bool HasTurn = true;
        public Point Pos;
        public Color Color;
        
        public int Health = 100;
        public int Regen;
        
        public abstract int GetDamageLevel();
        public abstract void TakeDamage(int amount);
          
        protected Dungeon Dungeon;
        protected Room CurrentRoom;

        public void SetPosition(Point pos) {
            Pos = pos;
        }

        public void SetDungeon(Dungeon dun) {
            Dungeon = dun;
        }
        
        public bool IsDead() {
            return Health <= 0;
        }
        
        public void Regenerate() {
            if (IsDead() == false) {
                Health += Regen;                
                if (Health > 100) {
                    Health = 100;
                }
            }
        }

        public Room findRoom() {
            foreach (Room room in Dungeon.Rooms)
            {
                if (room.isInside(Pos))
                {
                    return room;
                }
            }
            return new Room(new Point(-1, -1), new Point(-1, -1));
        }

        public bool TryMove(Direction direction) {
            Room currentRoom = new Room(new Point(-1, -1), new Point(-1, -1));
            Point newPos = Pos.Copy();
            
            switch (direction) {
            case Direction.NORTH:
                newPos.Y += -1;
                break;
            case Direction.SOUTH:
                newPos.Y += 1;
                break;
            case Direction.EAST:
                newPos.X += 1;
                break;
            case Direction.WEST:
                newPos.X += -1;
                break;
            default:
                return false;
            }

            currentRoom = findRoom();
            
            // check if moving to new room
            if (!currentRoom.isInside(newPos)) {
                bool found = false;
                foreach (Point pos in currentRoom.Doors.Keys) {
                    if (Pos == pos && currentRoom.Doors[pos].isInside(newPos)) {
                        if (this.GetType().IsSubclassOf(typeof(Monster))) {
                            currentRoom.Monsters.Remove((Monster) this);
                            currentRoom.Doors[pos].AddMonster((Monster) this);
                        }
                        found = true;
                        currentRoom = currentRoom.Doors[pos];
                    
                        break;
                    }
                }
                if (!found) {
                    return false;
                }
            }
            
            // check if there's a monster on the new position
            foreach (Monster monster in currentRoom.Monsters) {
                if (monster.Pos == newPos) {
                    if (this.GetType().IsSubclassOf(typeof(Hero))) {
                        monster.TakeDamage(GetDamageLevel());  
                        
                        Console.WriteLine("Monster health at {0}", monster.Health);
                    }      
                    if (!monster.IsDead()) {
                        return true;
                    } 
                    break;
                } 
            }
            
            if (currentRoom.isInside(newPos)) {
                Pos = newPos;

                return true;    
            }
            return false;
        }
    }
}