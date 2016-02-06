using snake.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{

    class Program
    {
        public static int level = 1;
        public static int score = 0;
       
        static void Main(string[] args)
        {
            while (level <= Directory.GetFiles(@"C:\Users\ww\Documents\Visual Studio 2013\Projects\PT_labs\zmeika\zmeika\bin\Debug\Levels").Length)//gets the files from level until finds the last element
            {
                Game.Init();
                Game.LoadlLevel(level);
                while (Game.isActive)
                {
                    Game.Draw();

                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Game.snake.Move(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            Game.snake.Move(0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            Game.snake.Move(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            Game.snake.Move(1, 0);
                            break;
                        case ConsoleKey.Escape:
                            Game.isActive = false;
                            break;
                        case ConsoleKey.F2:
                            Game.Save();
                            break;
                        case ConsoleKey.F3:
                            Game.Resume();
                            break;
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
