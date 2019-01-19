using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameNS;
using FileHandlerNS;
using System.IO;

namespace Sokoban
{
    public partial class GameBoardForm : Form
    {
        protected GameController GameController;
        protected IGameView View;
        protected IFileable callMeBackforDetails;
        string Filename;

        public void SetParent(Form parent)
        {
            MdiParent = parent;
        }

        public GameBoardForm(IGameView view, GameController gController)
        {
            GameController = gController;
            View = view;
            InitializeComponent();
            View.SetMain(this);
        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog LoadDialog = new OpenFileDialog();
            LoadDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            LoadDialog.FilterIndex = 2;
            LoadDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "MapSaves");

            if (LoadDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = LoadDialog.OpenFile()) != null)
                {
                    Filename = LoadDialog.FileName;
                    GameController.MakeMap(Filename);
                    MoveCountNumber.ResetText();
                    PlayerMoveHistory.ResetText();
                    ResetBtn.Enabled = false;
                    undoBtn.Enabled = false;
                    StartGameButton.Enabled = true;
                    mapDisplay.Visible = true;
                }
            }
            else { return; }
        }

        public void MakeTable(int col, int row, List<MapItem> theMap)
        {
            mapDisplay.Controls.Clear();
            mapDisplay.ColumnCount = col;
            mapDisplay.RowCount = row;
            int length = theMap.Count();
            foreach(MapItem m in theMap)
            {
                mapDisplay.Controls.Add(CreatePic(m), m.PosY, m.PosX);
            }
        }
        private PictureBox CreatePic(MapItem m)
        {
            PictureBox pic = new PictureBox()
            {
                Name = "Icon" + m.PosX.ToString() + m.PosY.ToString(),
                Size = new System.Drawing.Size(50, 50),
                Image = GetSign(m.Sign),
                Margin = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom
            };
        return pic;
        }

        private Bitmap GetSign(char sign)
        {
            switch (sign)
            {
                case '#':
                    return Properties.Resources.wall;

                case '$':
                    return Properties.Resources.block;

                case '+':
                    return Properties.Resources.playerOnGoal;

                case '@':
                    return Properties.Resources.player;

                case ' ':
                    return Properties.Resources.empty;

                case '.':
                    return Properties.Resources.goal;

                case '*':
                    return Properties.Resources.blockOnGoal;

                default:
                    return Properties.Resources.empty;
            }
        }

        public void UpdateMap(List<MapItem> Map)
        {
            if (Map != null)
            {
                foreach (var obj in Map)
                {
                    var test = mapDisplay.GetControlFromPosition(obj.PosY, obj.PosX);
                    mapDisplay.Controls.Remove(test);
                    mapDisplay.Controls.Add(CreatePic(obj), obj.PosY, obj.PosX);
                }
            }
            else
            {
                ResetBtn.Enabled = true;
            }
        }

        public void MakeMap()
        {
            GameController.TestMap();
            mapDisplay.Visible = true;
            StartGameButton.Enabled = true;
        }

        private void GameBoardForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
            }
        }

        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void GameBoardForm_KeyDown(object sender, KeyEventArgs e)
        {
            Direction Move = Direction.Up;
            if (StartGameButton.Enabled == false)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        Move = Direction.Up;
                        break;
                    case Keys.Down:
                        Move = Direction.Down;
                        break;
                    case Keys.Right:
                        Move = Direction.Right;
                        break;
                    case Keys.Left:
                        Move = Direction.Left;
                        break;
                    default:
                        break;
                }
                GameController.Move(Move);
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            StartGameButton.Enabled = false;
            ResetBtn.Enabled = true;
            undoBtn.Enabled = true;
            PlayerMoveHistory.Enabled = true;
            PlayerMoveHistoryLabel.Enabled = true;
            MoveCountNumber.Enabled = true;
            MoveCountLabel.Enabled = true;

            ActiveControl = mapDisplay;
        }

        public void AddMoveCount(string message)
        {
            MoveCountNumber.Text = message;
        }

        public void AddMoveHistory(string moveHistory)
        {
            PlayerMoveHistory.Text = moveHistory;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            GameController.Reset();
            ResetBtn.Enabled = false;
            StartGameButton.Enabled = true;
            PlayerMoveHistory.Enabled = false;
            PlayerMoveHistoryLabel.Enabled = false;
            MoveCountNumber.Enabled = false;
            MoveCountLabel.Enabled = false;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            GameController.Undo();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileBox = new SaveFileDialog();

            SaveFileBox.Filter = "txt files (*.txt)|*.txt";
            SaveFileBox.FilterIndex = 2;
            SaveFileBox.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SavedGameStates");
            saveFileDialog1.DefaultExt = "txt";

            if (SaveFileBox.ShowDialog() == DialogResult.OK)
            {
                Filename = SaveFileBox.FileName;
            }
            else { return; }
            GameController.SaveFile(Filename, callMeBackforDetails);
            MessageBox.Show("You file is saved with '-gameState': " + Environment.NewLine + Filename);
        }

        public Game GetSave()
        {
            return GameController.GetASave();
        }

        public string GetFileName()
        {
            return GameController.GetFileName();
        }

        public void SetMap(string level)
        {
            GameController.SetMap(level);
        }

        public void SetMapState(Tuple<string, string, string> game_state_file)
        {

            GameController.SetMap(game_state_file.Item1);
            AddMoveCount(game_state_file.Item2);
            AddMoveHistory(game_state_file.Item3);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void loadStateBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SavedGameStates");
            saveFileDialog1.DefaultExt = "txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                GameController.MakeMap(filename);
                BaseForm.LoadGameStateEvent();
                StartGameButton.Enabled = true;
                mapDisplay.Visible = true;
            }
        }
    }
}
