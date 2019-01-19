using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelDesignNS
{
    public interface ILevelDesignController
    {
        void Start(Form parent);
        void Stop();

        char[,] GetMap();

        void Load(char[,] map);
    }
}
