using snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake
{
    [Serializable]
    public class Wall : Drawer
    {
        public Wall()
        {
            sign = '#';
        }
    }
}
