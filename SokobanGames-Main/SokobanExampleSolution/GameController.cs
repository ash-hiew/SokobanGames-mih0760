using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNS;
using FileHandlerNS;

namespace Sokoban
{
    public class GameController : IGameController
    {
        Game GameModel;
        private IGameView View;
        protected string File;
        protected string defaultLevel = "#########," +
                                        "#-------#," +
                                        "#---$---#," +
                                        "#---@---#," +
                                        "#---.---#," +
                                        "#-------#," +
                                        "#----$--#," +
                                        "#--.----#," +
                                        "#########";


        private List<MapItem> Map;

        public GameController(Game game, IGameView view)
        {
            GameModel = game;
            View = view;
        }

        public void MakeMap(string filename)
        {
            File = filename;
            BaseForm.LoadGameEvent();

            int col = GameModel.GetColumnCount();
            int row = GameModel.GetRowCount();

            Map = GameModel.CreateMap();
            View.MakeTable(col, row, Map);
        }

        public void SetMap(string level)
        {
            string[] map = level.Split(',');
            
            GameModel.SetLevel(map);
        }

        public void Reset()
        {
            GameModel.Restart();
            Map = GameModel.GetMap().Items;
            View.UpdateMap(Map);
            GameModel.GetMap().Updates = new List<MapItem>();
            View.GetGameStats(GameModel.GetMoveCount(), GameModel.GetMoveHistory());
        }

        public void Undo()
        {
            GameModel.Undo();
            Map = GameModel.GetMap().Updates;
            View.UpdateMap(Map);
            GameModel.GetMap().Updates = new List<MapItem>();
            View.GetGameStats(GameModel.GetMoveCount(), GameModel.GetMoveHistory());
        }

        public void Move(Direction direction)
        {
            if (GameModel.IsFinished() == false)
            {
                GameModel.Move(direction);
                Map = GameModel.GetMap().Updates;
                View.UpdateMap(Map);
                GameModel.GetMap().Updates = new List<MapItem>();
                View.GetGameStats(GameModel.GetMoveCount(), GameModel.GetMoveHistory());
                if (GameModel.IsFinished() == true)
                {
                    string msg = String.Format("Nice! You completed the level in {0} moves!", GameModel.GetMoveCount());
                    View.DisplayMessage(msg);
                    View.UpdateMap(null);
                }
            }
        }

        public void SaveFile(string fileName, IFileable callMeBackforDetails)
        {
            File = fileName;
            BaseForm.SaveFileEvent();
        }

        public Game GetASave()
        {
            return GameModel;
        }

        public Game GetModel()
        {
            return GameModel;
        }

        public string GetFileName()
        {
            return File;
        }

        public List<MapItem> GetMap()
        {
            return GameModel.CreateMap();
        }

        public void TestMap()
        {
            int col = GameModel.GetColumnCount();
            int row = GameModel.GetRowCount();
            Map = GameModel.CreateMap();
            View.MakeTable(col, row, Map);
        }
    }
}
