using System.Drawing;

namespace SnakeBattle
{
    public class Tail : WorldObject
    {
        public Tail Leading { get; set; }
        public Tail Driven { get; set; }

        public Tail(Point position)
        {
            Position = position;
            Color = Color.OrangeRed;
        }
    }
}