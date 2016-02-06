using snake;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Models
{
    public class Game
    {
        public static bool isActive;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            isActive = true;
            snake = new Snake();
            food = new Food();
            wall = new Wall();

            snake.body.Add(new Point { x = 5, y = 10 }); //initial point of the head of the snake
            food.body.Add(new Point { x = 8, y = 15 });// The 1st position of the food
            //colors of the items
            food.color = ConsoleColor.Green;
            wall.color = ConsoleColor.White;
            snake.color = ConsoleColor.Yellow;

            Console.SetWindowSize(24, 32);

        }
        public static void LoadlLevel(int level)
        {

            FileStream stream = new FileStream(string.Format(@"Levels\MapLevel{0}.txt", level), FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);//reads the file level

            string line;
            int row = -1;
            int col = -1;

            while ((line = reader.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            reader.Close();
            stream.Close();
        }

        public static void Save()
        {
            wall.Save();
            snake.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snake.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(1, 26);
            Console.WriteLine("Level: " + Program.level);
            Console.SetCursorPosition(1, 27);
            Console.WriteLine("Eaten food: " + Program.score);
            Console.SetCursorPosition(1, 28);
            Console.WriteLine("Press F3 ");
            Console.SetCursorPosition(1, 29);
            Console.WriteLine("Press F2 ");
            Console.SetCursorPosition(1, 30);
            Console.WriteLine("Press Escape ");

        }
        public static void RandomSnake()
        {
            snake.body[0].x = new Random().Next(0, 24);
            snake.body[0].y = new Random().Next(0, 24);

            for (int i = 0; i < wall.body.Count; ++i)
            {
                if (snake.body[0].x == wall.body[i].x && snake.body[0].y == wall.body[i].y)
                {
                    RandomSnake();
                }
                else
                {
                    continue;
                }
            }
        }
    }
}