# SnakeBattle
Version 1.1

### Установка и запуск
1. Клонировать репозиторий
2. Открыть в Visual Studio 2015 (C# 6.0)
3. Построить решение и запустить

### Как создать и выполнить отладку собственного ИИ
1. Создать новый dll проект в решении **SnakeBattle**
2. Добавить в него ссылку на проект **PluginInterface**
3. Создать новый класс и унаследовать его от интерфейса **ISmartSnake**
4. Реализуйте интерфейс **ISmartSnake**
5. Добавьте ссылку на проект вашего ИИ в проект **Launcher**
6. Постройте решение и запустите

### Как запустить **SnakeBattle** с плагином вашего ИИ
1. Поместите ваш dll и dll вашего друга в папку с **Launcher.exe**
2. Запустите **Launcher.exe** и нажмите кнопку **Launch**

# Объяснение кода

### Интерфейс ISmartSnake

Move enum описывает все возможные движения змейки
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
Свойства позволяют передвигать вашу змейку или менять направление её движения раз в ход. Также, вы можете указать имя и цвет головы.
```csharp
string Name { get; set; }
Move Direction { get; set; }
bool Reverse { get; set; }
Color Color { get; set; }
```
Метод **Startup** запускается один раз при подключении ИИ. Переменная *size* содержит размеры поля. 
В переменной *stones* хранятся координаты статических объектов (в данный момент - камней).
```csharp
void Startup(Size size, List<Point> stones);
```

Метод **Update** запускается каждый раз при обновлении логики.
Переменная *position* хранит координаты головы змеи.
В *heads* содержатся координаты голов всех змей.
В *tails* содержатся координаты тел всех змей.
В *food* находятся координаты всех клеток с едой.
```csharp
void Update(Point position, List<Point> heads, List<Point> tails, List<Point> food);
```

### Пример плагина случайного ИИ 
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
# Скриншоты
### Linux
<p align="center">  
  <img src="https://github.com/lyftzeigen/SnakeBattle/raw/master/Screenshots/Linux/Battlefield.png"/>
</p>
