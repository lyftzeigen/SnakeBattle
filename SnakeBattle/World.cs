using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SnakeBattle
{
    public sealed class World : IDisposable
    {
        public int BlockSize { get; set; }
        public Size SizeInPixels { get; set; }
        public ObjectController Controller { get; set; }

        public double BorderGenerationTime { get; set; }
        public double TerrainGenerationTime { get; set; }
        public double FoodGenerationTime { get; set; }
        public double PluginLoadingTime { get; set; }
        public double LogicUpdateTime { get; set; }

        private int TerrainCount { get; set; }
        private int TerrainPower { get; set; }
        private int FoodCount { get; set; }
        private Size Size { get; set; }

        public World(int blockSize, int worldWidth, int worldHeight, int terrainCount, int terrainPower, int foodCount)
        {
            BlockSize = blockSize;
            Size = new Size(worldWidth, worldHeight);
            SizeInPixels = new Size(worldWidth * (blockSize + 2), worldHeight * (blockSize + 2));

            TerrainCount = terrainCount;
            TerrainPower = terrainPower;
            FoodCount = foodCount;

            Controller = new ObjectController(Size);

            GenerateBorders();
            GenerateTerrain();
            GenerateFood();
            LoadPluginSnakes();
        }

        public void Startup()
        {
            Controller.Startup();
        }

        public void Update()
        {
            var dt = DateTime.Now;
            Controller.Update();
            LogicUpdateTime = (DateTime.Now - dt).TotalMilliseconds;
        }

        private void GenerateBorders()
        {
            var dt = DateTime.Now;
            for (int i = 0; i < Size.Width; i++)
            {
                Controller.Add(new Stone(new Point(i, 0)));
                Controller.Add(new Stone(new Point(i, Size.Height - 1)));
            }

            for (int i = 0; i < Size.Height; i++)
            {
                Controller.Add(new Stone(new Point(0, i)));
                Controller.Add(new Stone(new Point(Size.Width - 1, i)));
            }
            BorderGenerationTime = (DateTime.Now - dt).TotalMilliseconds;
        }

        private void GenerateTerrain()
        {
            var dt = DateTime.Now;
            var rnd = new Random();

            var grid = new int[Size.Width, Size.Height];

            for (int i = 0; i < TerrainCount; i++)
            {
                var stack = new Stack<Point>();
                var power = rnd.Next(1, TerrainPower);

                var initial = new Point(rnd.Next(0, Size.Width), rnd.Next(0, Size.Height));

                grid[initial.X, initial.Y] = power;

                stack.Push(initial);

                while (stack.Count > 0)
                {
                    var point = stack.Pop();
                    var find = Controller.GetObjects(point);

                    if (find.All(fobj => fobj == null))
                    {
                        Controller.Add(new Stone(point));

                        foreach (var p in Controller.GetAdjacentPoints(point))
                        {
                            var friction = rnd.Next(1, 10);

                            if (grid[point.X, point.Y] > friction)
                            {
                                grid[p.X, p.Y] = grid[point.X, point.Y] - friction;
                                stack.Push(p);
                            }
                        }
                    }
                }
            }
            TerrainGenerationTime = (DateTime.Now - dt).TotalMilliseconds;
        }

        private void GenerateFood()
        {
            var dt = DateTime.Now;
            var rnd = new Random();

            while (Controller.GetObjects(typeof(Food)).Count < FoodCount)
            {
                var initial = new Point(rnd.Next(1, Size.Width), rnd.Next(1, Size.Height));

                if (Controller.GetObjects(initial).All(obj => obj == null))
                {
                    Controller.Add(new Food(initial));
                }
            }

            if (FoodGenerationTime <= double.Epsilon)
            {
                FoodGenerationTime = (DateTime.Now - dt).TotalMilliseconds;
            }
        }

        private void LoadPluginSnakes()
        {
            var dt = DateTime.Now;
            var rnd = new Random();
            var plugins = PluginController.LoadPlugins();

            foreach (var plugin in plugins)
            {
                while (true)
                {
                    var initial = new Point(rnd.Next(1, Size.Width), rnd.Next(1, Size.Height));

                    if (Controller.GetObjects(initial).All(obj => obj == null))
                    {
                        var head = new Head(initial, plugin);

                        Controller.Add(head);

                        Tail current = head;

                        for (int i = 0; i < 2; i++)
                        {
                            var t = new Tail(initial);
                            current.Driven = t;
                            t.Leading = current;
                            current = t;
                            Controller.Add(t);
                        }

                        break;
                    }
                }
            }
            PluginLoadingTime = (DateTime.Now - dt).TotalMilliseconds;
        }

        public void DisablePlugin(string name)
        {
            foreach (Head head in Controller.GetObjects(typeof(Head)))
            {
                if (head.Name == name)
                {
                    foreach (var tail in Controller.GetSnake(head))
                    {
                        Controller.DeleteObject(tail);
                    }
                    break;
                }
            }
        }

        public void Dispose()
        {
            Controller.Dispose();
        }
    }
}