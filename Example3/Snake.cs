using snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using snake;

namespace snake
{
    public class Snake : Drawer
    {
        public int MyProperty { get; set; }
        

        public Snake()

        {
            sign = 'o';
        }
        public void YouWon()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 15);
            Console.WriteLine("You won the game!");
            Console.WriteLine("Your score is " + score);
            Game.isActive = false;
        }

        public void GameOver()
        {  //Function when snake faces with wall or border of the window
            Console.Clear();
            Console.SetCursorPosition(10, 15);
            Console.WriteLine("Game over!"); //Message that will be displayed on position 20x10
            Game.isActive = false; //The end of the game
        }
        
        public bool IsEmptyPoint(int rx, int ry)
        { //Check is the point where food is going to appear is empty or not
            for (int i = 0; i < body.Count; ++i) //check each sign of the snake
            {
                if (body[i].x == rx && body[i].y == ry)
                {//if this sign of the faces with random coordinate this place is not empty
                    return false; //It is not empty, thus, value is false
                }
            }
            for (int i = 0; i < Game.wall.body.Count; ++i) //check each sign of the walls
            {
                if (Game.wall.body[i].x == rx && Game.wall.body[i].y == ry) //if this sign of the wall faces with random coordinate this place is not empty
                {
                    return false; // It is not empty, hense value is false
                }
            }

            return true; //In another case it is true
        }
        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            if (Game.snake.body[0].x == 0 || Game.snake.body[0].x == 24 || Game.snake.body[0].y == 0 || Game.snake.body[0].y == 24)
            // if snake crosses the border
            {
                GameOver();
            }

                      
            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            //check for eating the food
            {
                Program.score++;
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });// increase in lenght while eating

                if (Program.score % 4 == 0 && Program.score != 0)// every 4th food new level
                {
                    Program.level++;
                    Console.Clear();//clears everything snake become original size
                    Game.isActive = false;
                }

                if(Program.score == 12)
                {
                    YouWon();
                }
                RandomFood();
            }

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)//check for walls
                {
                    GameOver();
                }
               
            }
        }

        private void RandomFood()
        {
            Game.food.body[0].x = new Random().Next(0, 24);//
            Game.food.body[0].y = new Random().Next(0, 24);

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.wall.body[i].x && Game.food.body[0].y == Game.wall.body[i].y)
                {
                    RandomFood();
                }
                else
                {
                    continue;
                }
            }

            for (int i = 0; i < Game.snake.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.snake.body[i].x && Game.food.body[0].y == Game.snake.body[i].y)
                {
                    RandomFood();
                }
                else
                {
                    continue;
                }
            }
        }

        public string score { get; set; }
    }
}