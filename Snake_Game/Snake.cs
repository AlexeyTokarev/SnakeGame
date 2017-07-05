using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;

            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);

                return true;
            }
            else return false; 
        }

        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }
        
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i])) return true;
            }
            return false;
 
        }
        public void HandleKey(ConsoleKey key) // Реакция на нажатие стрелочек
        {
            if (key == ConsoleKey.LeftArrow)
            {                
                if ((direction == Direction.LEFT) || (direction == Direction.RIGHT)) return;
                else direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if ((direction == Direction.LEFT) || (direction == Direction.RIGHT)) return;
                else direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if ((direction == Direction.UP) || (direction == Direction.DOWN)) return;
                else direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if ((direction == Direction.UP) || (direction == Direction.DOWN)) return;
                else direction = Direction.DOWN;
            }
        }
    }
}
