using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNS;

namespace Sokoban
{
    public interface IGameView
    {       
        void Out(string game);
        void UpdateMap(List<MapItem> Map);
        void MakeTable(int col, int row, List<MapItem> theMap);
        void SetMain(GameBoardForm Form);
        void GetGameStats(int movecount, string movelist);
        void DisplayMessage(string message);

    }
}
