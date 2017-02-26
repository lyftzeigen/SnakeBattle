# SnakeBattle

### Installation and run
1. Clone repository
2. Open with Visual Studio 2015 (C# 6.0)
3. Build and Run

### How to create and debug your own AI
1. Create new dll project into **SnakeBattle** solution
2. Add reference on **PluginInterface** project
3. Create new class and inherit it from **ISmartSnake** interface
4. Implement **ISmartSnake** interface
5. Add reference on your AI project to **Launcher** project
6. Build solution and run

### How to run **SnakeBattle** with your AI plugin
1. Place your and your friends dll's into the **Launcher.exe** directory
2. Run **Launcher.exe** and hit launch button

# Screenshots
### Linux
<p align="center">  
  <img src="https://github.com/lyftzeigen/SnakeBattle/raw/master/Screenshots/Linux/Battlefield.png"/>
</p>

# Code explanation

### ISmartSnake interface

The Move enum describes a possible snake movement.
```csharp
public enum Move
{
    Nothing = 0,
    Up = 1,
    Right = 2,
    Down = 3,
    Left = 4
}
```
The properties allows you move snake in preferred direction or reverse it once time at turn. Also you can set name and color of the head.
```csharp
string Name { get; set; }
Move Direction { get; set; }
bool Reverse { get; set; }
Color Color { get; set; }
```
The **Startup** method runs ones when you AI plugged. The *size* contains battlefield dimensions.
The *stones* contains static objects coordinates (stones at this moment).

```csharp
void Startup(Size size, List<Point> stones);
```

The **Update** method runs every time when logic updated.
The *position* contains snake head coordinates.
The *heads* contains coordinates of all heads.
The *tails* contains coordinates of all snakes bodies.
The *food* contains coordinates of all food objects.

```csharp
void Update(Point position, List<Point> heads, List<Point> tails, List<Point> food);
```

### Example of Random AI plugin
```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using PluginInterface;

namespace BotRandomSnake
{
    public class RandomSnake : ISmartSnake
    {
        public string Name { get; set; } = "RandomSnake";
        public Color Color { get; set; } = Color.Black;
        public Move Direction { get; set; }
        public bool Reverse { get; set; }

        private DateTime dt = DateTime.Now;
        private static Random rnd = new Random();

        public void Startup(Size size, List<Point> stones)
        {
        }

        public void Update(Point position, List<Point> heads, List<Point> tails, List<Point> food)
        {
            // Змейка двигается в случайном направлении
            Direction = (Move) rnd.Next(1, 5);

            // Змейка разворачивается каждую секунду (1000мс)
            if ((DateTime.Now - dt).TotalMilliseconds > 1000)
            {
                Reverse = true;
                dt = DateTime.Now;
            }
        }
    }
}
```
