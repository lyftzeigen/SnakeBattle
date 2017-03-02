using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace SnakeBattle
{
    public class BlockRenderer : IDisposable
    {
        public double DrawTime { get; set; }

        private World world;
        private Pen opacity = new Pen(Color.FromArgb(0, 0, 0, 0));
        private SolidBrush blood = new SolidBrush(Color.FromArgb(70, Color.Red));
        private Dictionary<Color, Pen> penDictionary = new Dictionary<Color, Pen>();
        private Dictionary<Color, SolidBrush> brushDictionary = new Dictionary<Color, SolidBrush>();
        private DateTime dt;

        public BlockRenderer(World world)
        {
            this.world = world;
        }

        private void DrawBlock(Graphics g, Point position, Color color)
        {
            if (!penDictionary.Keys.Contains(color))
            {
                penDictionary.Add(color, new Pen(color));
            }

            if (!brushDictionary.Keys.Contains(color))
            {
                brushDictionary.Add(color, new SolidBrush(color));
            }

            g.DrawRectangle(penDictionary[color], position.X * (world.BlockSize + 2), position.Y * (world.BlockSize + 2),
                world.BlockSize, world.BlockSize);
            g.DrawRectangle(opacity, position.X * (world.BlockSize + 2) + 1, position.Y * (world.BlockSize + 2) + 1,
                world.BlockSize - 2, world.BlockSize - 2);
            g.FillRectangle(brushDictionary[color], position.X * (world.BlockSize + 2) + 2,
                position.Y * (world.BlockSize + 2) + 2, world.BlockSize - 3, world.BlockSize - 3);
        }

        private void DrawBlood(Graphics g, Point position, Color color)
        {
            if (!penDictionary.Keys.Contains(color))
            {
                penDictionary.Add(color, new Pen(color));
            }

            if (!brushDictionary.Keys.Contains(color))
            {
                brushDictionary.Add(color, new SolidBrush(color));
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(penDictionary[color], position.X * (world.BlockSize + 2), position.Y * (world.BlockSize + 2),
                position.X * (world.BlockSize + 2) + world.BlockSize, position.Y * (world.BlockSize + 2) + world.BlockSize);
            g.DrawLine(penDictionary[color], position.X * (world.BlockSize + 2) + world.BlockSize, position.Y * (world.BlockSize + 2),
                position.X * (world.BlockSize + 2), position.Y * (world.BlockSize + 2) + world.BlockSize);
            g.FillRectangle(blood, position.X * (world.BlockSize + 2), position.Y * (world.BlockSize + 2),
                world.BlockSize, world.BlockSize);

            g.SmoothingMode = SmoothingMode.None;
        }

        public void Draw(Graphics g)
        {
            dt = DateTime.Now;

            var typesToDraw = new[] { typeof(Stone), typeof(Food), typeof(Tail), typeof(Head) };

            foreach (var type in typesToDraw)
            {
                var objects = world.Controller.GetObjects(type).ToArray();

                foreach (var obj in objects)
                {
                    if (obj != null)
                    {
                        DrawBlock(g, obj.Position, obj.Color);
                    }
                }
            }

            foreach (var obj in world.Controller.GetObjects(typeof(Blood)).ToList())
            {
                if (obj != null)
                {
                    DrawBlood(g, obj.Position, obj.Color);
                }
            }

            DrawTime = (DateTime.Now - dt).TotalMilliseconds;
        }

        public void Dispose()
        {
            opacity.Dispose();
            penDictionary.Clear();
            brushDictionary.Clear();
        }
    }
}