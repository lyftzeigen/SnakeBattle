using System.Drawing;

namespace SnakeBattle
{
    public class Blood : Tail
    {
        public Blood(Point position) : base(position)
        {
            Color = Color.Black;
        }
    }
}
