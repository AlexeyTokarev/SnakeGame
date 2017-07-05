using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Vertical_Line : Figure
    {
        public Vertical_Line(int yUp, int yDown,int x , char sym)     // Создает горизонтальную линию
        {   
            pList= new List<Point>();
            
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }
}
