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

namespace SokobanExampleSolution
{
    public partial class GameBoardF : Form
    {
        protected GameController GameControl;

        public GameBoardF()
        {
            InitializeComponent();
        }

        public GameBoardF(GameController gController)
        {
            GameControl = gController;
            InitializeComponent();

        }

        public void MakeTable(int col, int row, List<MapItem> theMap)
        {
            this.gameLayoutPanel1.ColumnCount = col;
            this.gameLayoutPanel1.RowCount = row;
            int length = theMap.Count();
            foreach (MapItem m in theMap)
            {
                this.gameLayoutPanel1.Controls.Add(MakeLabel(m), m.CordY, m.CordX);
            }
        }

        private Label MakeLabel(MapItem m)
        {
            Label label = new Label()
            {
                Name = "Icon" + m.CordX.ToString() + m.CordY.ToString(),
                Text = m.Sign.ToString(),
                Size = new System.Drawing.Size(15, 15),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            return label;
        }

        private void GameBoardForm_KeyDown(object sender, KeyEventArgs e)
        {
            Direction Move = Direction.Up;
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
            }
            GameControl.Move(Move);
        }

        public void UpdateMap(List<MapItem> Map)
        {
            if (Map != null)
            {
                foreach (var obj in Map)
                {
                    var test = this.gameLayoutPanel1.GetControlFromPosition(obj.CordY, obj.CordX);
                    test.Text = obj.Sign.ToString();
                }
            }
            else
            {
                MessageBox.Show("Congrats You won! ");
                
            }

        }
    }
}
