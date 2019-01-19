using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNS
{
   public class MapItem
    {
        public int PosX;
        public int PosY;
        public char Sign;

        public MapItem(int x, int y, char sign )
        {
            PosX = x;
            PosY = y;
            Sign = sign;
        }
    }
}
