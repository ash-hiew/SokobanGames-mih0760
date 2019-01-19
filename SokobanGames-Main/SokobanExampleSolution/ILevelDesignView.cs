using LevelDesignNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public interface ILevelDesignView
    {
        void Start(Form parent);
        void Stop();
        event MapChangedHandler MapChanged;
        void SetErrors(string[] errors);
        void Loaded(char[,] map);
    }
}
