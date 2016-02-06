using snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake
{
    [Serializable]
    public class Food : Drawer
    {
        public Food()
        {
            sign = '$';
        }
    }
}
