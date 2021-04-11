using System;
using System.Windows.Forms;
using System.Drawing;
using DungeonCrawler.Players;
using DungeonCrawler.Items;

namespace DungeonCrawler.Forms {
    public class DungeonForm : Panel {
        private Dungeon dungeon;
        
        public DungeonForm(Hero hero) {
            this.Height = 600;
            this.Width = 600;
            
            dungeon = DungeonParser.MakeDungeon(hero, "C:\\Users\\Simon\\Desktop\\Projects\\DungeonCrawler" + "\\2012-dungeon.map");
            //dungeon = DungeonGenerator2.GenerateDungeon(hero);
            
            this.Paint += new PaintEventHandler(OnPaint);
        }
        
        protected void OnPaint(object sender, PaintEventArgs e) {
            int scale = dungeon.PointScaleFactor;
            int mScale = Convert.ToInt32(scale * 0.9);
            
            if (dungeon.Hero != null) {
                Pen myPen = new Pen(Color.Blue);
                myPen.Width = 2;
                    
                System.Drawing.Point[] points =
                {
                    new System.Drawing.Point(10 + dungeon.Hero.Pos.X * scale + mScale, 10 + dungeon.Hero.Pos.Y * scale + scale - mScale),
                    new System.Drawing.Point(10 + dungeon.Hero.Pos.X * scale + scale - mScale, 10 + dungeon.Hero.Pos.Y * scale + mScale),
                };
                e.Graphics.DrawLines(myPen, points);         
            }
            
            foreach (Room room in dungeon.Rooms) {
                Pen penRoom = new Pen(Color.Black);
                penRoom.Width = 2;
                e.Graphics.DrawRectangle(penRoom, 
                    10 + room.TopLeft.X * scale, 
                    10 + room.TopLeft.Y * scale,
                    (room.BottomRight.X - room.TopLeft.X) * scale,
                    (room.BottomRight.Y - room.TopLeft.Y) * scale);
                
                foreach (Point pos in room.Doors.Keys) {
                    Pen penDoor = new Pen(Color.White);
                    penDoor.Width = 2;

                    int xscale = 0;
                    int yscale = scale;
                    if (pos.Y == room.TopLeft.Y) {
                        xscale = scale;
                        yscale = 0;
                    }
                    
                    System.Drawing.Point[] points =
                    {
                        new System.Drawing.Point(10 + pos.X * scale, 10 + pos.Y * scale),
                        new System.Drawing.Point(10 + pos.X * scale + xscale, 10 + pos.Y * scale + yscale),
                    };
                    e.Graphics.DrawLines(penDoor, points);        
                }
                
                foreach (Monster monster in room.Monsters) {
                    if (!monster.IsDead()) {   
                        e.Graphics.DrawRectangle(new Pen(monster.Color),
                            10 + monster.Pos.X * scale + scale - mScale,
                            10 + monster.Pos.Y * scale + scale - mScale,
                            2*mScale - scale,
                            2*mScale - scale);
                    }
                    
                }
                
                foreach (Item item in room.Items) {
                    System.Drawing.Point[] points =
                    {
                        new System.Drawing.Point(10 + item.Pos.X * scale + scale - mScale/2, 10 + item.Pos.Y * scale + scale - mScale),
                        new System.Drawing.Point(10 + item.Pos.X * scale + scale - mScale, 10 + item.Pos.Y * scale + mScale ),
                        new System.Drawing.Point(10 + item.Pos.X * scale + mScale, 10 + item.Pos.Y * scale + mScale),  
                    };
                    e.Graphics.DrawLines(new Pen(item.Color), points);
                }
            }
        }

        public void OnKeyDown(Keys e) {            
            dungeon.OnKeyDown(e);
        }
    }
}