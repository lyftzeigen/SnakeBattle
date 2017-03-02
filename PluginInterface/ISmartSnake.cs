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

    public class Snake
    {
        public Point Position { get; set; }
        public double Health { get; set; }
        public List<Point> Tail { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Snake))
            {
                return false;
            }

            var snake = obj as Snake;
            return Position.Equals(snake.Position) && Health.Equals(snake.Health);
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode() ^ Health.GetHashCode();
        }
    }

    public interface ISmartSnake
    {
        string Name { get; set; }
        Move Direction { get; set; }
        bool Reverse { get; set; }
        Color Color { get; set; }

        void Startup(Size size, List<Point> stones);
        void Update(Snake snake, List<Snake> enemies, List<Point> food, List<Point> dead);
    }
}