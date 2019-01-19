using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandlerNS;

namespace LevelDesignNS
{
    public interface ILevelDesigner
    {
        void SetSize(int x, int y);
        void SetItem(Parts item);
        void PlaceItem(int x, int y);
        string[] DisplayErrorMessages();

        char[,] GetMap();
        void SetMap(char[,] map);

    }
}
