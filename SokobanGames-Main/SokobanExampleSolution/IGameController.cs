using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNS;
using FileHandlerNS;
using Sokoban;

namespace Sokoban
{
    public interface IGameController
    {
        void MakeMap(string filename);
        void SetMap(string level);
        void Reset();
        void Undo();
        void Move(Direction direction);
        void SaveFile(string fileName, IFileable callMeBackforDetails);
        Game GetModel();
        List<MapItem> GetMap();
        void TestMap();
    }
}
