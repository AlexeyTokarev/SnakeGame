using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Snake_Game
{
    class Program
    {
        const Int16 sizeX = 80;
        const Int16 sizeY = 25;

        static void Main(string[] args)
        {
            
            Console.SetBufferSize(sizeX, sizeY); // Размер консольки
            Console.Title = "Змейка";

            startProgramm: // Метка для начала работы программы
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Walls walls = new Walls(sizeX, sizeY);
            walls.Draw();
            
            // Отрисовка точек                       
            Point p = new Point(4,5,'*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            byte snakeSpeed = 150;
            int ochki = 0;

            FoodCreator foodCreator = new FoodCreator(sizeX, sizeY, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())                    
                    break;

                Thread.Sleep(snakeSpeed);
                
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    ochki++;
                    food.Draw();
                    if ((snakeSpeed <= 70) && (snakeSpeed > 55)) snakeSpeed -= 15;
                    else if ((snakeSpeed <= 55) && (snakeSpeed > 45)) snakeSpeed -= 10;
                    else if ((snakeSpeed <= 45) && (snakeSpeed > 35)) snakeSpeed -= 5;
                    else if ((snakeSpeed <= 35) && (snakeSpeed > 20)) snakeSpeed -= 3;
                    else if (snakeSpeed <= 20) snakeSpeed = 20;
                    else snakeSpeed -= 20;                     
                }
                else { snake.Move(); }
                
                
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }              
                
            }
            metka1:
            WriteGameOver(ochki);
                        
                ConsoleKeyInfo key1 = Console.ReadKey();

                if ((key1.Key!=ConsoleKey.Enter)&&(key1.Key!=ConsoleKey.Escape)) goto metka1;
                else if (key1.Key == ConsoleKey.Enter) goto startProgramm;
                else if (key1.Key == ConsoleKey.Escape) return;
            
                          
        }

        static void WriteGameOver(int ochki)
        {
            Console.Clear(); // Очистка консоли, чтоб на экране не мешали остатки змейки
            Console.ForegroundColor = ConsoleColor.White;
            Walls walls = new Walls(sizeX, sizeY);
            walls.Draw();

            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("=============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("         ВАШ СЧЕТ:  " + ochki + "",xOffset, yOffset++);           
            WriteText("=============================", xOffset, yOffset++);
            yOffset++;
            yOffset++;
            WriteText("Для продолжения нажмите ENTER", xOffset, yOffset++);
            WriteText("  Для выхода нажмите ESCAPE  ", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);

        }
    }
}
