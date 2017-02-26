using System.Collections.Generic;
using System.Drawing;

namespace PluginInterface
{
    public enum Move
    {
        Nothing = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4
    }

    public interface ISmartSnake
    {
        string Name { get; set; }
        Move Direction { get; set; }
        bool Reverse { get; set; }
        Color Color { get; set; }

        void Startup(Size size, List<Point> stones);
        void Update(Point position, List<Point> heads, List<Point> tails, List<Point> food);
    }
}