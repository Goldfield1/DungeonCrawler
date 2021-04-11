using System.Drawing;
using System.Windows.Forms;

namespace DungeonCrawler {
    public class Point {
        public int X;
        public int Y;

        public Point target { get; internal set; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }
        
        public Point() : this(0, 0) { }

        public static bool operator ==(Point point1, Point point2) {
            return point1.X == point2.X && point1.Y == point2.Y;
        }
        
        public static bool operator !=(Point point1, Point point2) {
            return point1.X != point2.X || point1.Y != point2.Y;
        }
        
        public Point Copy() {
            return new Point(X, Y);
        }
        
        public override string ToString() {
            return $"Point({X},{Y})";
        }
    }
}