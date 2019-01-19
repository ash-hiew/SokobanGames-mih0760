using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesignNS
{
    public interface IChecker
    {
        void MapErrors(char[,] map);
        void ErrorCheck();
        string[] GetErrors();
    }
}
