using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameNS;

namespace Sokoban
{
    class GameFormView : IGameView
    {
        protected GameBoardForm Game;
       

        public List<MapItem> GetMap(List<MapItem> Map)
        {
            return Map;
        }

        public void GetGameStats(int movecount, string moveHistory)
        {
            Game.AddMoveCount(movecount.ToString());
            Game.AddMoveHistory(moveHistory);
        }
        

        public void MakeTable(int col, int row, List<MapItem> theMap)
        {
            Game.MakeTable(col, row, theMap);
            //Game.MakeTable(theMap);
            
        }

        public void Out(string game)
        {
            throw new NotImplementedException();
        }

        public void SetMain(GameBoardForm Form)
        {
            Game = Form;
        }

        public void UpdateMap(List<MapItem> Map)
        {
            Game.UpdateMap(Map);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
