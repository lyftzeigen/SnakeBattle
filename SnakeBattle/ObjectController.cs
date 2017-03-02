using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PluginInterface;

namespace SnakeBattle
{
    public class ObjectController : IDisposable
    {
        public Size WorldSize { get; set; }
        public Dictionary<Point, List<WorldObject>> FastItems { get; set; }
        public Dictionary<Type, List<WorldObject>> FastTypes { get; set; }

        public ObjectController(Size size)
        {
            WorldSize = size;

            FastItems = new Dictionary<Point, List<WorldObject>>();
            FastTypes = new Dictionary<Type, List<WorldObject>>();
        }

        public void Add(WorldObject obj)
        {
            if (FastItems.ContainsKey(obj.Position))
            {
                FastItems[obj.Position].Add(obj);
            }
            else
            {
                FastItems.Add(obj.Position, new List<WorldObject>());
                FastItems[obj.Position].Add(obj);
            }

            if (FastTypes.ContainsKey(obj.GetType()))
            {
                FastTypes[obj.GetType()].Add(obj);
            }
            else
            {
                FastTypes.Add(obj.GetType(), new List<WorldObject>());
                FastTypes[obj.GetType()].Add(obj);
            }
        }

        public List<WorldObject> GetObjects(Point position)
        {
            if (FastItems.ContainsKey(position))
            {
                var list = FastItems[position];

                if (list.Count > 0)
                {
                    return list;
                }
            }

            return new List<WorldObject>();
        }

        public List<WorldObject> GetObjects(Type type)
        {
            if (FastTypes.ContainsKey(type))
            {
                var list = FastTypes[type];

                if (list.Count > 0)
                {
                    return list;
                }
            }

            return new List<WorldObject>();
        }

        public void DeleteObject(WorldObject obj)
        {
            FastItems[obj.Position].Remove(obj);
            FastTypes[obj.GetType()].Remove(obj);
        }

        public List<Point> GetAdjacentPoints(Point position)
        {
            return new List<Point>
            {
                new Point(position.X, position.Y + 1),
                new Point(position.X + 1, position.Y),
                new Point(position.X, position.Y - 1),
                new Point(position.X - 1, position.Y)
            }.Where(arg => arg.X < WorldSize.Width && arg.X >= 0 && arg.Y < WorldSize.Height && arg.Y >= 0).ToList();
        }

        public List<Tail> GetSnake(Head head)
        {
            var ret = new List<Tail>();

            Tail current = head;

            while (current != null)
            {
                ret.Add(current);
                current = current.Driven;
            }

            return ret;
        }

        public void GrowSnake(Head head)
        {
            var snakeEnd = GetSnake(head).Last();
            var newTail = new Tail(snakeEnd.Position) { Color = snakeEnd.Color };
            snakeEnd.Driven = newTail;
            newTail.Leading = snakeEnd;
            Add(newTail);
        }

        public void ShrinkSnake(Head head)
        {
            var snake = GetSnake(head);
            var end = snake.Last();
            var point = end.Position;
            end.Leading.Driven = null;
            DeleteObject(end);
            var dead = new Blood(end.Position);
            Add(dead);
        }

        public void KillSnake(Head head)
        {
            var snake = GetSnake(head);

            foreach (var tail in snake)
            {
                DeleteObject(tail);
            }
        }

        public void MoveObject(WorldObject obj, Point position)
        {
            // Syncronise Dictionaries before change position
            // Because position it is a key in Dictionary
            var objectsItems = FastItems[obj.Position];
            objectsItems.Remove(obj);

            var objectsTypes = FastTypes[obj.GetType()];
            objectsTypes.Remove(obj);

            obj.Position = position;

            Add(obj);
        }

        public Point DirectionToPoint(Head head)
        {
            if (head.Direction == Move.Up)
            {
                return new Point(head.Position.X, head.Position.Y - 1);
            }

            if (head.Direction == Move.Right)
            {
                return new Point(head.Position.X + 1, head.Position.Y);
            }

            if (head.Direction == Move.Down)
            {
                return new Point(head.Position.X, head.Position.Y + 1);
            }

            if (head.Direction == Move.Left)
            {
                return new Point(head.Position.X - 1, head.Position.Y);
            }

            return head.Position;
        }

        public bool Distansed(Point p1, Point p2)
        {
            return (p1.X - p2.X) != 0 || (p1.Y - p2.Y) != 0;
        }

        private void UpdateSnakeDirection()
        {
            var food = new List<Point>();

            foreach (var item in GetObjects(typeof(Food)))
            {
                food.Add(item.Position);
            }

            var dead = new List<Point>();

            foreach (var item in GetObjects(typeof(Blood)))
            {
                dead.Add(item.Position);
            }

            var heads = GetObjects(typeof(Head)).ToList();

            foreach (Head head in heads)
            {
                var snake = new Snake()
                {
                    Position = head.Position,
                    Health = head.Health,
                    Tail = GetSnake(head).Skip(1).Select(obj => obj.Position).ToList()
                };

                var enemies = new List<Snake>();

                foreach (Head enemy in heads)
                {
                    if (enemy != head)
                    {
                        var s = new Snake()
                        {
                            Position = enemy.Position,
                            Health = enemy.Health,
                            Tail = GetSnake(enemy).Skip(1).Select(obj => obj.Position).ToList()
                        };

                        enemies.Add(s);
                    }
                }

                head.Update(snake, enemies, food, dead);
            }

        }

        private void UpdateSnakeMoving()
        {
            foreach (Head head in GetObjects(typeof(Head)).ToArray())
            {
                if (head.PenaltyTurns == 0)
                {
                    var destination = DirectionToPoint(head);
                    var prepositionLeading = head.Position;
                    var prepositionDriven = Point.Empty;

                    var find = GetObjects(destination);

                    if (find.Count == 0 || find.All(fobj => fobj.Permeable))
                    {
                        MoveObject(head, destination);

                        Tail current = head.Driven;

                        while (current != null)
                        {
                            if (Distansed(current.Position, current.Leading.Position))
                            {
                                prepositionDriven = current.Position;
                                MoveObject(current, prepositionLeading);
                            }

                            current = current.Driven;
                            prepositionLeading = prepositionDriven;
                        }
                    }
                }
                else
                {
                    head.PenaltyTurns--;
                }
            }
        }

        private void UpdateSnakeReverse()
        {
            foreach (Head head in GetObjects(typeof(Head)).ToArray())
            {
                if (head.Reverse)
                {
                    var snake = GetSnake(head);

                    if (snake.Count > 1)
                    {
                        var copy = snake.Select(tail => tail.Position).ToList();

                        copy.Reverse();

                        for (int i = 0; i < snake.Count; i++)
                        {
                            MoveObject(snake[i], copy[i]);
                        }
                    }

                    head.PenaltyTurns++;
                    head.Reverse = false;
                }
            }
        }

        private void UpdateFoodEating()
        {
            var heads = GetObjects(typeof(Head));

            foreach (Head head in heads)
            {
                var foods = GetObjects(head.Position).Where(obj => obj.GetType() == typeof(Food));
                var length = GetSnake(head).Count;

                foreach (var food in foods)
                {
                    if (head.Position == food.Position)
                    {
                        DeleteObject(food);

                        if (head.Health < 100)
                        {
                            head.Health += 20;

                            if (head.Health > 100)
                            {
                                head.Health = 100;
                            }

                            head.Score += 0.1;
                        }
                        else
                        {
                            head.FoodCollected++;

                            if (head.FoodCollected >= 10)
                            {
                                GrowSnake(head);
                                head.FoodCollected = 0;
                            }

                            head.Score += 0.25;
                        }

                        break;
                    }
                }
            }
        }

        public void UpdateSnakeHunting()
        {
            var heads = GetObjects(typeof(Head));

            foreach (Head attacking in heads)
            {
                var points = GetAdjacentPoints(attacking.Position);

                foreach (var point in points)
                {
                    foreach (Head victim in heads)
                    {
                        if (victim.Position == point)
                        {
                            var victimLength = GetSnake(victim).Count;
                            var attackingLength = GetSnake(attacking).Count;
                            var power = (attackingLength + 1.0) / (victimLength + 1.0) * 1.0;
                            victim.Health -= power * 22;
                            attacking.Score += 0.22 / power + 0.125;
                        }
                    }
                }
            }
        }

        public void UpdateSnakeDie()
        {
            var heads = GetObjects(typeof(Head));

            foreach (Head head in heads.ToList())
            {
                var snake = GetSnake(head);

                if (head.Health <= 0)
                {
                    if (snake.Count > 2)
                    {
                        ShrinkSnake(head);
                        head.Health = 100;
                    }
                    else
                    {
                        ShrinkSnake(head);
                        KillSnake(head);
                    }
                }
            }
        }

        public void Startup()
        {
            var stones = new List<Point>();
            foreach (var item in FastTypes[typeof(Stone)])
            {
                stones.Add(item.Position);
            }

            foreach (Head head in GetObjects(typeof(Head)))
            {
                head.Startup(WorldSize, stones);
            }
        }

        public void Update()
        {
            UpdateSnakeReverse();
            UpdateSnakeMoving();
            UpdateFoodEating();
            UpdateSnakeHunting();
            UpdateSnakeDie();
            UpdateSnakeDirection();
        }

        public void Dispose()
        {
            FastItems.Clear();
            FastTypes.Clear();
        }
    }
}