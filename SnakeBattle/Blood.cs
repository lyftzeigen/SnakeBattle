using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBattle
{
    public class Blood : Tail
    {
        public Blood(Point position) : base(position)
        {
            Color = Color.Black;
        }
    }
}
