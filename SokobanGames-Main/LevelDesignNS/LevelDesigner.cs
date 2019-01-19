using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandlerNS;

namespace LevelDesignNS
{
    public class LevelDesigner : ILevelDesigner
    {
        private char[,] Map { get; set; }
        private char Item { get; set; }
        internal protected IChecker Check;
        public LevelDesigner(IChecker check)
        {
            Check = check;
        }
        public void SetSize(int width, int height)
        {
            Map = new char[width, height];
        }

        public void SetItem(Parts item)
        {
            Item = (char)item;
        }

        public void PlaceItem(int x, int y)
        {
            Map[x, y] = Item;
        }

        public string[] DisplayErrorMessages()
        {
            Check.MapErrors(Map);
            Check.ErrorCheck();
            return Check.GetErrors();
        }

        public void SetMap(char[,] map)
        {
            Map = map;
        }

        public char[,] GetMap()
        {
            return Map;
        }

    }
}
