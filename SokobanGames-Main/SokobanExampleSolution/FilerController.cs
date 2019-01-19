using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileHandlerNS;
using GameNS;

namespace Sokoban
{
    public class FilerController : IFilerController
    {
        protected ISaver Saver;
        protected Game theGame;
        protected ILoader Loader;
        protected IFiler Filer;
        protected IGameFiler GameFileable;
        protected FilerForm View;
        protected FilerForm.FileEventHandler FileHandled;

        public FilerController(ISaver saver, ILoader loader, IFiler filer, IGameFiler gameFileable, Game game, FilerForm view)
        {
            Saver = saver;
            Loader = loader;
            View = view;
            theGame = game;
            Filer = filer;
            GameFileable = gameFileable;
            FileHandled = new FilerForm.FileEventHandler(OnFileEvent);
            View.FileHandled += FileHandled;
            Filer.CreateSaveFolder();
            View.SetDirectory(Filer.GetSaveLocation());
        }

        public Form Start()
        {
            return View;
        }

        public void ShowForm()
        {
            View.Show();
        }

        public void HideForm()
        {
            View.Hide();
        }

        public char[,] ReturnMap()
        {
            char[,] map = Loader.GetMap();
            return map;
        }

        public void game_save(string filename, Game callMeBackforDetails)
        {
            GameFileable.Save(filename, callMeBackforDetails);
        }

        public string game_load(string filename)
        {
            string file = GameFileable.Load(filename);
            return file;
        }

        public Tuple<string, string, string> game_state_load(string filename)
        {
            string file = GameFileable.Load(filename);
            string moveCount = GameFileable.GetSavedMoveCount();
            string moveHistory = GameFileable.GetSavedMoveHistory();

            return Tuple.Create(file, moveCount, moveHistory);
        }

        public void Ex_Save(char[,] map)
        {
            Saver.SetMap(map);
            View.DisableLoad();
            View.EnableSave();
        }

        public void Ex_Load()
        {
            View.DisableSave();
            View.EnableLoad();
        }

        public string ArrayToString(char[,] map)
        {
            Filer.SetMap(map);
            Filer.Compress();
            return Filer.GetMapString();
        }

        public void OnFileEvent(object sender, FilerForm.FileEventArgs e)
        {
            string name;
            if (e.Save)
            {
                Saver.SaveMap(View.GetFileName());
            }
            else if (e.Load)
            {
                name = View.GetFileName();
                Loader.LoadFile(name);
                BaseForm.SetLoadedMap();
            }
        }

        public void GetErrorMessages()
        {
            View.AddErrorsToListBox(Filer.Errors);
        }

    }
}
