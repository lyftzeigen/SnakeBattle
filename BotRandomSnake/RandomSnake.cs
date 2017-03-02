using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace BotRandomSnake
{
    public class RandomSnake : ISmartSnake
    {
        public Move Direction { get; set; }
        public bool Reverse { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        private DateTime dt = DateTime.Now;
        private static Random rnd = new Random();

        public void Startup(Size size, List<Point> stones)
        {
            Name = "RandomSnake";
            Color = Color.Black;
        }

        public void Update(Snake snake, List<Snake> enemies, List<Point> food, List<Point> dead)
        {
            // Змейка двигается в случайном направлении
            Direction = (Move)rnd.Next(1, 5);

            // Змейка разворачивается каждую секунду (1000мс)
            if ((DateTime.Now - dt).TotalMilliseconds > 1000)
            {
                Reverse = true;
                dt = DateTime.Now;
            }
        }
    }
}