using System.Drawing;

namespace SnakeBattle
{
    public class WorldObject
    {
        public Color Color { get; set; }
        public Point Position { get; set; }
        public bool Permeable { get; set; }

        public WorldObject()
        {
            Permeable = false;
        }
    }
}