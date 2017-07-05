using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Walls
    {
        List<Figure> wallList;
        
        public Walls(int mapWidht, int mapHeight)
        {
            wallList = new List<Figure>();
            // Отрисовка рамочки
            Horisontal_Line upLine = new Horisontal_Line(0, mapWidht-2, 0, '+');
            Horisontal_Line downLine = new Horisontal_Line(0, mapWidht - 2, mapHeight-1, '+');
            Vertical_Line leftLine = new Vertical_Line(0, mapHeight - 1, 0, '+');
            Vertical_Line rightLine = new Vertical_Line(0, mapHeight - 1, mapWidht - 2, '+');
           
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(rightLine);
            wallList.Add(leftLine); 
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
                
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
