using System.Collections.Generic;
using System.Drawing;
using PluginInterface;

namespace SnakeBattle
{
    public class Head : Tail
    {
        public string Name { get; set; }
        public Move Direction { get; set; }
        public bool Reverse { get; set; }

        private ISmartSnake plugin;

        public Head(Point position) : base(position)
        {
            Color = Color.Brown;
            Direction = Move.Nothing;
            plugin = null;
        }

        public Head(Point position, ISmartSnake brains) : base(position)
        {
            plugin = brains;
            Name = plugin.Name;
            Color = plugin.Color;
            Direction = Move.Nothing;
        }

        public void Startup(Size size, List<Point> stones)
        {
            if (plugin != null)
            {
                plugin.Startup(size, stones);
                Color = plugin.Color;
                Name = plugin.Name;
            }
        }

        public void Update(Point position, List<Point> heads, List<Point> tails, List<Point> food)
        {
            if (plugin != null)
            {
                plugin.Reverse = Reverse;
                plugin.Update(position, heads, tails, food);
                Direction = plugin.Direction;
                Reverse = plugin.Reverse;
            }
        }
    }
}