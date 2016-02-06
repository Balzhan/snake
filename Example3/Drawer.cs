using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using snake;
using System.Runtime.Serialization.Formatters.Binary;

namespace snake.Models
{
    [Serializable]
    public class Drawer
    {
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;
        public Drawer()
        {
            color = ConsoleColor.Blue;
        }

        public void Draw()
        {

            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Save()
        {
            string value = "";
            BinaryFormatter formatter = new BinaryFormatter();
            switch (sign)
            {
                case '#':
                    value = "wall.dat";
                    break;
                case 'o':
                    value = "snake.dat";
                    break;
                case '$':
                    value = "food.dat";
                    break;

            }
            FileStream stream = new FileStream(value, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, value);
            stream.Close();
        }

        public void Resume()
        {
            string file = "";
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();
            switch (sign)
            {
                case '#':
                    file = "wall.dat";
                    break;
                case '$':
                    file = "food.dat";
                    break;
                case '*':
                    file = "snake.dat";
                    break;
            }
        }
        public Microsoft.Win32.SafeHandles.SafeFileHandle value { get; set; }
    }
}
