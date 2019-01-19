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
    public partial class GameForm : Form
    {


        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(GameBoardForm main)
        {
            this.Parent = main;
         }

        public void MakeTable(int col, int row,List<MapItem> theMap)
        {
            this.gameLayoutPanel1.ColumnCount = col;
            this.gameLayoutPanel1.RowCount = row;
            foreach (MapItem m in theMap)
            {
                this.gameLayoutPanel1.Controls.Add(MakeLabel(m), m.CordY, m.CordX);
                //this.gameLayoutPanel1.Controls.Add(Image);
            }
        }

        private Label MakeLabel(MapItem m)
        {
            Label label = new Label();
            label.Name = "Icon" + m.CordX.ToString() + m.CordY.ToString();
            label.Text = m.Sign.ToString();
            label.Size = new System.Drawing.Size(15, 15);
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            return label;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    //GameControl.Move(Direction.Up);
                    break;
                case Keys.Down:
                    //this.UpdateMap(GameControl.Move(Direction.Down));
                    break;
                case Keys.Right:
                    //this.UpdateMap(GameControl.Move(Direction.Right));
                    break;
                case Keys.Left:
                    //GameControl.Move(Direction.Left);
                    break;
            }
        }
    }
}
