using System;
using System.Collections.Generic;
using DungeonCrawler.Players;

namespace DungeonCrawler {
    public class DungeonGenerator2 {

        public static Dungeon GenerateDungeon(Hero hero) {
            Dungeon dungeon = new Dungeon();
            
            Random ran = new Random();
            
            List<Room> rooms = new List<Room>();
            
            for (int i = 0; i < 21; i = i +3) {
                for (int j = 0; j < 21; j = j + 3) {
                    Room room = new Room(new Point(i, j), new Point(i + ran.Next(3,9), j + ran.Next(3,9)));
                    rooms.Add(room);
                }    
            }
            
           
            
            return dungeon;
        }

        private Point getRandomPointInCircle(int radius) {
            Random ran = new Random();

            var t = 2 * Math.PI * ran.NextDouble();
            var u = ran.Next(0, 10) + ran.NextDouble();
            var r = u;

            if (u > 1) {
                r = 2 - u;
            } 
            
            return  new Point(
                System.Convert.ToInt32(Math.Floor(radius*Math.Cos(t))), 
                System.Convert.ToInt32(Math.Floor(radius*Math.Sin(t)))
                );
        }
        
        
    }
}