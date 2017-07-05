using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point() { }

        public Point( int _x, int _y, char _sym) // Для простоты из класса Programm мы сразу передаем параметры
        {
            this.x = _x;
            this.y = _y;
            this.sym = _sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            { x = x + offset; }

            else if (direction == Direction.LEFT)
            { x = x - offset; }

            else if (direction == Direction.UP)
            { y = y - offset; }

            else if (direction == Direction.DOWN)
            { y = y + offset; }
        }

        public bool IsHit(Point p) // Проверка на равенство координат (змейка скушала еду)
        {
            return p.x == this.x && p.y == this.y; 
        }


        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public void Draw()  // Метод, который реализует прорисовку точки на консоли
        {
            Console.SetCursorPosition(x, y);  // На конкретную координату ставит курсор
            Console.Write(sym);               // Отображаем '*'
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
