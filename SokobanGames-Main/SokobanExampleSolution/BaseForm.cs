using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameNS;
using FileHandlerNS;

namespace Sokoban
{
    public delegate void FileHandled(object sender, EventArgs e);
    public partial class BaseForm : Form
    {
        protected FilerController FilerControl;
        protected GameBoardForm GameBoard;
        protected ILevelDesignController DesignControl;

        protected static event FileHandled FileSave;
        protected static event FileHandled FileLoad;
        protected static event FileHandled SetFile;
        protected static event FileHandled LoadGame;
        protected static event FileHandled LoadGameState;
        protected static event FileHandled SetSaveFile;
        protected static event FileHandled MapTest;
        protected FilerForm Filer;

        public BaseForm(GameBoardForm gameBoard, FilerController filerControl, ILevelDesignController designControl)
        {
            GameBoard = gameBoard;
            FilerControl = filerControl;
            DesignControl = designControl;
            FileSave += new FileHandled(ToSave);
            FileLoad += new FileHandled(ToLoad);
            SetFile += new FileHandled(SetLoaded);
            LoadGame += new FileHandled(ToLoadGame);
            LoadGameState += new FileHandled(ToLoadGameState);
            SetSaveFile += new FileHandled(SaveFile);
            MapTest += new FileHandled(LevelToGame);
            InitializeComponent();
            GameBoard.SetParent(this);
        }

        private void LevelToGame(object sender, EventArgs e)
        {
            GameBoard.Show();
            char[,] map = DesignControl.GetMap();
            string mapString = FilerControl.ArrayToString(map);
            GameBoard.SetMap(mapString);
            GameBoard.MakeMap();
        }

        private void SaveFile(object sender, EventArgs e)
        {
            string file = GameBoard.GetFileName();
            Game callMeBackforDetails = GameBoard.GetSave();
            FilerControl.game_save(file, callMeBackforDetails);
            FilerControl.HideForm();
        }

        private void ToLoadGame(object sender, EventArgs e)
        {
            string file = GameBoard.GetFileName();
            string level = FilerControl.game_load(file);
            GameBoard.SetMap(level);
        }

        private void ToLoadGameState(object sender, EventArgs e)
        {
            string file = GameBoard.GetFileName();
            GameBoard.SetMapState(FilerControl.game_state_load(file));
        }

        private void SetLoaded(object sender, EventArgs e)
        {
            char[,] map = FilerControl.ReturnMap();
            if (map != null)
            {
                DesignControl.Load(map);
                FilerControl.HideForm();
            }
            else
            {
                FilerControl.GetErrorMessages();
            }

        }

        private void ToLoad(object sender, EventArgs e)
        {
            FilerControl.Ex_Load();
            FilerControl.ShowForm();
        }

        private void ToSave(object sender, EventArgs e)
        {
            FilerControl.ShowForm();
            FilerControl.Ex_Save(DesignControl.GetMap());
        }

        private void playGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameBoard.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public static void SaveFileEvent()
        {
            SetSaveFile(null, EventArgs.Empty);
        }

        public static void SetLoadedMap()
        {
            SetFile(null, EventArgs.Empty);
        }

        public static void LoadGameEvent()
        {
            LoadGame(null, EventArgs.Empty);
        }

        public static void LoadGameStateEvent()
        {
            LoadGameState(null, EventArgs.Empty);
        }

        public static void FilerSave()
        {
            FileSave(null, EventArgs.Empty);
        }

        public static void FilerLoad()
        {
            FileLoad(null, EventArgs.Empty);
        }

        public static void TestMap()
        {
            MapTest(null, EventArgs.Empty);
        }

        private void designALevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignControl.Start(this);
        }
    }
}
