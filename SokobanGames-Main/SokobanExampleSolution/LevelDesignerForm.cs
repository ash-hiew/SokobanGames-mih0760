using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LevelDesignNS;
using FileHandlerNS;
using System.IO;
using System.Text.RegularExpressions;

namespace Sokoban
{
    public partial class LevelDesignerForm : Form, ILevelDesignView
    {

        public event MapChangedHandler MapChanged;

        protected Parts Part;
        protected Image Pic;
        protected int mapWidth;
        protected int mapHeight;
        protected Form FilerParent;
        protected Dictionary<char, Image> Items;

        protected void OnMapChange(MapChangedEventArgs e)
        {
            MapChanged(this, e);
        }

        public void Start(Form parent)
        {
            MdiParent = parent;
            FilerParent = parent;
            InitializeComponent();
            Show();
            Part = Parts.Empty;
            Clear();
            Items = new Dictionary<char, Image>();
            Items.Add((char)Parts.Wall, Properties.Resources.wall);
            Items.Add((char)Parts.Player, Properties.Resources.player);
            Items.Add((char)Parts.Goal, Properties.Resources.goal);
            Items.Add((char)Parts.Block, Properties.Resources.block);
            Items.Add((char)Parts.PlayerOnGoal, Properties.Resources.playerOnGoal);
            Items.Add((char)Parts.BlockOnGoal, Properties.Resources.blockOnGoal);
            Items.Add((char)Parts.Empty, Properties.Resources.empty);
            Items.Add('\0', Properties.Resources.empty);
            Pic = Items['-'];
            saveBtn.Enabled = false;
            testBtn.Enabled = false;
            errorCheckBtn.Enabled = false;
        }

        public void Stop()
        {
            Hide();
        }

        private void buildMapBtn_Click(object sender, EventArgs e)
        {
            Clear();
            Pic = Items['-'];
            int y = (int)ySize.Value;
            int x = (int)xSize.Value;
            mapWidth = x;
            mapHeight = y;
            MapChangedEventArgs MapChange = new MapChangedEventArgs();
            MapChange.CoordX = x;
            MapChange.CoordY = y;
            MapChange.Part = Part;
            MapChange.Setting = true;
            OnMapChange(MapChange);
            SetUpGrid(x, y);
            errorCheckBtn.Enabled = true;
            saveBtn.Enabled = false;
            testBtn.Enabled = false;
        }

        private void SetUpGrid(int x, int y)
        {
            for (int j = 0; j < x; j++)
            {
                for (int k = 0; k < y; k++)
                {
                    CreateGridElements(j, k);
                }
            }
        }

        private void CreateGridElements(int j, int k)
        {
            Panel Item = new Panel();
            Item.Location = new Point(j * 56 + 10, k * 56 + 15);
            Item.Size = new Size(55, 55);
            Item.BackgroundImage = Pic;
            Item.Click += new EventHandler(SetImage);
            Item.Name = j.ToString() + "/" + k.ToString();
            Item.Click += (sender, e) => SetItem(sender, e, Item.Name);
            mapContainer.Controls.Add(Item);
        }

        public void SetItem(object sender, EventArgs e, string name)
        {
            MapChangedEventArgs MapChange = new MapChangedEventArgs();
            Regex regex = new Regex("/");
            string[] location = regex.Split(name);
            MapChange.CoordX = Int32.Parse(location[0]);
            MapChange.CoordY = Int32.Parse(location[1]);
            MapChange.Part = Part;
            MapChange.Setting = false;
            OnMapChange(MapChange);

        }

        private void SetImage(object sender, EventArgs e)
        {
            ((Panel)sender).BackgroundImageLayout = ImageLayout.Stretch;
            ((Panel)sender).BackgroundImage = Pic;
        }

        public void Loaded(char[,] map)
        {
            Clear();
            int count = 0;
            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int k = 0; k < map.GetLength(1); k++)
                {
                    CreateGridElements(j, k);
                    mapContainer.Controls[count].BackgroundImage = Items[map[j, k]];
                    count++;
                }
            }
        }

        public void SetErrors(string[] errors)
        {
            errorListBox.Items.Clear();
            foreach (string error in errors)
            {
                if (error != null)
                {
                    errorListBox.Items.Add(error);
                }
            }
        }

        private void Clear()
        {
            mapContainer.Controls.Clear();
        }

        private void addWallBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.Wall;
            Pic = Items[(char)Part];
        }

        private void addPlayerBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.Player;
            Pic = Items[(char)Part];
        }

        private void addBlockBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.Block;
            Pic = Items[(char)Part];
        }

        private void addGoalBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.Goal;
            Pic = Items[(char)Part];
        }

        private void addPlayerOnGoalBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.PlayerOnGoal;
            Pic = Items[(char)Part];
        }

        private void addBlockOnGoalBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.BlockOnGoal;
            Pic = Items[(char)Part];
        }

        private void addEmptyBtn_CheckedChanged(object sender, EventArgs e)
        {
            Part = Parts.Empty;
            Pic = Items[(char)Part];
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            errorCheckBtn.Enabled = true;
            BaseForm.FilerLoad();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            BaseForm.FilerSave();
        }

        private void errorCheckBtn_Click(object sender, EventArgs e)
        {
            MapChangedEventArgs check = new MapChangedEventArgs();
            check.Check = true;
            check.Setting = false;
            OnMapChange(check);
            if (errorListBox.Items.Count < 1)
            {
                errorListBox.Items.Add("No errors found!");
                saveBtn.Enabled = true;
                testBtn.Enabled = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            Clear();
            Pic = Items['-'];
            SetUpGrid(mapWidth, mapHeight);
        }

        private void testBtn_Click_1(object sender, EventArgs e)
        {
            BaseForm.TestMap();
        }
    }
}
