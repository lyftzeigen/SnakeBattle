using System.Collections.Generic;
using System.Drawing;
using PluginInterface;

namespace SnakeBattle
{
    public class Head : Tail
    {
        private ISmartSnake plugin;

        public string Name { get; set; }
        public double Health { get; set; }
        public double Score { get; set; }
        public int FoodCollected { get; set; }
        public int PenaltyTurns { get; set; }

        public bool Reverse { get; set; }
        public Move Direction { get; set; }

        public Head(Point position) : base(position)
        {
            plugin = null;
            Name = "Noname";
            Color = Color.Brown;
            Health = 100;
            Direction = Move.Nothing;
        }

        public Head(Point position, ISmartSnake brains) : base(position)
        {
            plugin = brains;
            Name = plugin.Name;
            Color = plugin.Color;
            Health = 100;
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

        public void Update(Snake snake, List<Snake> enemies, List<Point> food, List<Point> dead)
        {
            if (plugin != null)
            {
                plugin.Reverse = Reverse;
                plugin.Update(snake, enemies, food, dead);
                Direction = plugin.Direction;
                Reverse = plugin.Reverse;
            }
        }
    }
}