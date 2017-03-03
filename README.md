# SnakeBattle v1.1.0

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

Перечисление **Move** описывает все возможные движения змейки
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

Класс **Snake** содержит следующую информацию о змейке:
Свойство *Position* содержит информацию о координатах головы змейки.
Свойство *Health* содержит информацию о здоровье змейки.
Свойство *Tail* является массивом, содержащим координаты хвоста змейки.
```csharp
public class Snake
{
    public Point Position { get; set; }
    public double Health { get; set; }
    public List<Point> Tail { get; set; }
}
```

Свойства интерфейса **ISmartSnake** позволяют передвигать вашу змейку или менять направление её движения раз в ход. Также, вы можете указать имя и цвет головы.
```csharp
Move Direction { get; set; }
bool Reverse { get; set; }
string Name { get; set; }
Color Color { get; set; }
```

Метод **Startup** запускается один раз при подключении ИИ (плагина). Параметр *size* содержит размеры поля. 
В параметре *stones* хранятся координаты статических объектов (камней).
```csharp
void Startup(Size size, List<Point> stones);
```

Метод **Update** запускается каждый раз при обновлении логики.
Параметр *snake* хранит информацию о вашей змейке.
В *enemies* содержится информация о всех остальных змейках.
В *food* содержатся координаты пищи.
В *dead* находятся координаты мертвых хвостов змеек.
```csharp
void Update(Snake snake, List<Snake> enemies, List<Point> food, List<Point> dead);
```

### Пример плагина случайного ИИ 
```csharp
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

```
# Скриншоты
### Linux
<p align="center">  
  <img src="https://github.com/lyftzeigen/SnakeBattle/raw/master/Screenshots/Linux/Battlefield.png"/>
</p>

### Windows
<p align="center">  
    <img src="https://github.com/lyftzeigen/SnakeBattle/blob/master/Screenshots/Windows/Battlefield.png"/>
</p>
