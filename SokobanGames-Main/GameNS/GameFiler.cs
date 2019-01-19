using System;
using System.Collections.Generic;
using System.IO;
using FileHandlerNS;

namespace GameNS
{
    public class GameFiler : IGameFiler, IValidator
    {
        public string LevelName { get; set; }
        public string SaveLocation { get; private set; }
        public string SavedMoveCount { get; private set; }
        public string SavedMoveHistory { get; private set; }

        public GameFiler()
        {

        }

        public bool CheckValidSymbol(char check)
        {
            Array Items = Enum.GetValues(typeof(Parts));
            foreach (Parts item in Items)
            {
                if (check == (char)item || check == ',' || check == '\0')
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckValidString(string check)
        {
            foreach (char item in check)
            {
                if (CheckValidSymbol(item) != true)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckIfFileExists(string name)
        {
            return File.Exists(name);
        }

        public bool CheckValidFileFormat(string name)
        {
            if (Path.GetExtension(name) == ".txt")
            {
                return true;
            }
            else { return false; }
        }

        public string Load(string filename)
        {
            if (CheckIfFileExists(filename))
            {
                if (CheckValidFileFormat(filename))
                {
                    string[] result = File.ReadAllLines(filename);

                    string myString = string.Join("", result[0]);
                    if(CheckValidString(myString))
                    {
                        string text = myString.Replace("\"", "");


                        if (result.Length != 1)
                        {
                            SavedMoveCount = result[1];
                            SavedMoveHistory = result[2];
                        }

                        return text;

                    }  else { throw (new Exception("Invalid characters in the file!")); }
                } else { throw (new Exception("Invalid file format. Must be .txt!")); } 
            } else { throw (new Exception("The file doesn't exist!")); }
        }

        public string GetSavedMoveCount()
        {
            return SavedMoveCount;
        }

        public string GetSavedMoveHistory()
        {
            return SavedMoveHistory;
        }

        public void Save(string filename, Game callMeBackforDetails)
        {
            int rowSize = callMeBackforDetails.GetRowCount();
            int colSize = callMeBackforDetails.GetColumnCount();
            List<MapItem> CurrentGame = callMeBackforDetails.GetMap().Items;
            List<char> parts = new List<char>();
            foreach (MapItem item in CurrentGame)
            {
                parts.Add(item.Sign);
            }

            char[] lines = parts.ToArray();
            string result = "";

            SetSaveLocation(filename);
            using (StreamWriter outputFile = new StreamWriter(SaveLocation, false))
            {
                string str = "";
                foreach (char line in lines)
                {
                    result += line;
                }
                int chunkSize = colSize;
                int resultLength = result.Length;
                for (int i = 0; i < resultLength; i += chunkSize)
                {
                    str += result.Substring(i, chunkSize) + ",";
                }
                outputFile.WriteLine(str.TrimEnd(','));
                string moveCount = callMeBackforDetails.GetMoveCount().ToString();
                string moveHistory = callMeBackforDetails.GetMoveHistory();
                outputFile.WriteLine(moveCount);
                outputFile.WriteLine(moveHistory);
            }

        }

        public void SetSaveLocation(string filename)
        {
            string CurrentFolder = Directory.GetCurrentDirectory();
            string pathString = Path.Combine(CurrentFolder, "SavedGameStates");
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }
            string levelName = Path.GetFileNameWithoutExtension(filename) + "-gameState.txt";
            SaveLocation = Path.Combine(pathString, levelName);
        }
    }
}
