using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Sokoban
{
    public partial class FilerForm : Form, IFilerFormView
    {
        public FilerForm()
        {
            InitializeComponent();
            linkRecent.Enabled = false;
            GetFileList();
        }

        public event FileEventHandler FileHandled;
        protected string Filename;
        protected string theDirectory;


        public void DisableLoad()
        {
            btnLoad.Enabled = false;
        }

        public void EnableLoad()
        {
            btnLoad.Enabled = true;
        }

        public void DisableSave()
        {
            btnSave.Enabled = false;
        }

        public void EnableSave()
        {
            btnSave.Enabled = true;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog LoadDialog = new OpenFileDialog();
            listMsg.Items.Clear();
            LoadDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            LoadDialog.FilterIndex = 2;
            LoadDialog.InitialDirectory = theDirectory;
            string RecentSaveFile = Directory.GetParent(theDirectory).ToString();
            RecentSaveFile += @"\RecentSave.txt";
            LoadDialog.DefaultExt = "txt";

            if (File.Exists(RecentSaveFile))
            {
                string RecentSave = String.Join(",", File.ReadAllLines(RecentSaveFile));
                string[] RecentLevelSplit = RecentSave.Split('\\');
                string RecentLevel = RecentLevelSplit.Last().ToString();
            }
            else
            {
                File.Create(RecentSaveFile);
            }

            if (LoadDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = LoadDialog.OpenFile()) != null)
                {
                    Filename = LoadDialog.FileName;
                }
            }
            else { return; }

            FindRecentFile(RecentSaveFile);
            string[] LevelPath = Filename.Split('\\');
            string Level = LevelPath.Last().ToString();
            labelLoadItem.Text = Level;
            FileEventArgs FileEvent = new FileEventArgs();
            FileEvent.Save = false;
            FileEvent.Load = true;
            OnFileEvent(FileEvent);
            FileExistsLoaded();
            GetFileList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            listMsg.Items.Clear();
            SaveFileDialog SaveDialog = new SaveFileDialog();

            SaveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            SaveDialog.FilterIndex = 2;
            SaveDialog.InitialDirectory = theDirectory;
            SaveDialog.DefaultExt = "txt";

            string RecentSaveFile = Directory.GetParent(theDirectory).ToString();
            RecentSaveFile += @"\RecentSave.txt";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                Filename = SaveDialog.FileName;
            }
            else
            {
                return;
            }
            string[] LevelPath = Filename.Split('\\');
            FindRecentFile(RecentSaveFile);

            string LevelName = LevelPath.Last().ToString();
            SaveItemLabel.Text = LevelName;
            FileEventArgs FileEvent = new FileEventArgs();
            FileEvent.Save = true;
            FileEvent.Load = false;
            OnFileEvent(FileEvent);
            FileExistsSaved();
            GetFileList();
        }

        public void OnFileEvent(FileEventArgs e)
        {
            FileHandled(this, e);
        }

        private void FindRecentFile(string RecentSaveFile)
        {
            if (!File.Exists(RecentSaveFile))
            {
                File.WriteAllText(RecentSaveFile, String.Empty);
            }
            string[] readLines = File.ReadAllLines(RecentSaveFile);
            List<string> writeLines = new List<string>();
            foreach (string line in readLines)
            {
                if (line != Filename)
                {
                    writeLines.Add(line);
                }
            }
            writeLines.Add(Filename + Environment.NewLine);
            recentPathLabel.Text = Filename;
            File.AppendAllText(RecentSaveFile, Filename + Environment.NewLine);
            SetRecentLink();
        }

        private void GetFileList()
        {
            listFiles.Items.Clear();
            string location = Path.Combine(Directory.GetCurrentDirectory(), "MapSaves");
            string[] files = Directory.GetFiles(location);
            foreach (string file in files)
            {
                string[] fileSplit = file.Split('\\');
                string filename = fileSplit.Last().ToString();
                listFiles.Items.Add(filename);
            }

        }

        public void FileExistsSaved()
        {
            if (File.Exists(Filename))
            {
                listMsg.Items.Add("File saved successfully");
            }
            else
            {
                listMsg.Items.Add("Error: File cannot be saved");
            }

        }

        public void FileExistsLoaded()
        {
            if (File.Exists(Filename) || (Path.GetFileNameWithoutExtension(Filename) == ".txt"))
            {
                listMsg.Items.Add("File Loaded Successfully");
            }
            else
            {
                listMsg.Items.Add("Error: File cannot be loaded");
            }
        }

        private string GetRecentFilePath()
        {
            string RecentSaveFile = Directory.GetParent(theDirectory).ToString();
            RecentSaveFile += @"\RecentSave.txt";
            string path;
            path = "no file";
            if (File.Exists(RecentSaveFile))
            {
                path = File.ReadLines(RecentSaveFile).Last();

            }
            if (path != "no file")
            {
                linkRecent.Enabled = true;
                recentPathLabel.Text = path;
            }
            return path;
        }

        public string GetFileName()
        {
            return Filename;
        }

        public void SetDirectory(string directory)
        {
            theDirectory = directory;
            SetRecentLink();
        }

        public void SetRecentLink()
        {
            string path = GetRecentFilePath();
            string[] sep = new string[] { "\\" };
            string[] pathData = path.Split(sep, StringSplitOptions.None);
            linkRecent.Text = pathData.Last().ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public delegate void FileEventHandler(object sender, FileEventArgs e);

        public class FileEventArgs : EventArgs
        {
            public bool Save;
            public bool Load;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            listMsg.Items.Clear();
            SaveFileDialog SaveDialog = new SaveFileDialog();

            SaveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            SaveDialog.FilterIndex = 2;
            SaveDialog.InitialDirectory = theDirectory;
            SaveDialog.DefaultExt = "txt";

            string RecentSaveFile = Directory.GetParent(theDirectory).ToString();
            RecentSaveFile += @"\RecentSave.txt";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                Filename = SaveDialog.FileName;
            }
            else
            {
                return;
            }
            string[] LevelPath = Filename.Split('\\');
            RecentFile(RecentSaveFile);

            string LevelName = LevelPath.Last().ToString();
            SaveItemLabel.Text = LevelName;
            FileEventArgs FileEvent = new FileEventArgs();
            FileEvent.Save = true;
            FileEvent.Load = false;
            OnFileEvent(FileEvent);
            FileExistsSaved();
            GetFileList();
        }

        private void RecentFile(string RecentSaveFile)
        {
            if (!File.Exists(RecentSaveFile))
            {
                File.WriteAllText(RecentSaveFile, String.Empty);
            }
            string[] readLines = File.ReadAllLines(RecentSaveFile);
            List<string> writeLines = new List<string>();
            foreach (string line in readLines)
            {
                if (line != Filename)
                {
                    writeLines.Add(line);
                }
            }
            writeLines.Add(Filename + Environment.NewLine);
            recentPathLabel.Text = Filename;
            File.AppendAllText(RecentSaveFile, Filename + Environment.NewLine);
            SetRecentLink();
        }

        public void AddErrorsToListBox(string[] errors)
        {
            if (errors != null)
            {
                for(int i = 0; i < 3; i++)
                {
                    listMsg.Items.Add(errors[i]); 
                }
            }

        }

        public void setParent(Form parent)
        {
            Parent = parent;
        }

        private void linkRecent_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Filename = GetRecentFilePath();
            FileEventArgs FileEvent = new FileEventArgs();
            FileEvent.Save = false;
            FileEvent.Load = true;
            OnFileEvent(FileEvent);
            FileExistsLoaded();
        }
    }
}
