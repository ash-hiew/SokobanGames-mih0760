using System.Drawing;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace FileHandlerNS
{
    public class Filer : IFiler, ILoader, ISaver, IValidator
    {
        public string LevelName { get; set; }
        public string SaveLocation { get; private set; }
        public char[,] MapArray { get; set; }
        public string CompressedMapString { get; set; }
        public string ExpandedFileString { get; set; }
        public string[] Errors { get; set; }

        public void Get_LevelName(string fileName)
        {
            LevelName = fileName;
        }

        public void SetMap(char[,] map)
        {
            MapArray = map;
        }

        public string GetMapString()
        {
            return CompressedMapString;
        }

        public string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }

        public void CreateSaveFolder()
        {
            string folderName = "MapSaves";
            string CurrentFolder = GetCurrentDir();
            string pathString = Path.Combine(CurrentFolder, folderName);
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }
            SetSaveLocation();
        }

        public void SetSaveLocation()
        {
            string CurrentFolder = GetCurrentDir();
            SaveLocation = Path.Combine(CurrentFolder, "MapSaves");
        }

        public string GetSaveLocation()
        {
            return SaveLocation;
        }

        public void Compress()
        {
            string result = "";
            for (int y = 0; y < MapArray.GetLength(0); y++)
            {
                for (int x = 0; x < MapArray.GetLength(1); x++)
                {
                    result += MapArray[y, x].ToString();
                }

                if (y != MapArray.GetLength(0) - 1)
                {
                    result += ",";
                }
            }
            CompressedMapString = result;
        }

        public void SaveMap(string name)
        {
            SetSaveLocation();
            Compress();
            File.WriteAllText(Path.Combine(SaveLocation, name), CompressedMapString);
        }

        public string ReadFile(string fileName)
        {
            return File.ReadAllText(Path.Combine(SaveLocation, fileName));
        }

        public void SetFileString(string map)
        {
            ExpandedFileString = map;
        }

        public int GetColSize()
        {
            string map = ExpandedFileString;
            int count = 0;
            for (int x = 0; x <= map.Length - 1; x++)
            {
                if (map[x] == ',' || map.Length - 1 == x)
                {
                    count++;
                }
            }

            return count;
        }

        public int GetRowSize()
        {
            string map = ExpandedFileString;
            int count = 0;
            foreach (char item in map)
            {
                if (item == ',')
                {
                    break;
                }
                count++;
            }
            return count;
        }

        public void Expand()
        {
            string map = ExpandedFileString;
            int col = GetRowSize();
            int row = GetColSize();
            char[,] mapArr = new char[row, col];
            int count = 0;
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    if (map[count] == ',')
                    {
                        count++;
                    }
                    mapArr[y, x] = map[count];
                    count++;
                }
            }
            MapArray = mapArr;
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

        public void LoadFile(string fileName)
        {
            SetSaveLocation();
            SetErrors();
            string LoadString;
            if (CheckIfFileExists(fileName))
            {
                if (CheckValidFileFormat(fileName))
                {
                    LoadString = ReadFile(fileName);
                    if (CheckValidString(LoadString))
                    {
                        SetFileString(LoadString);
                        Expand();
                    }
                    else { AddError(2, "Invalid file format. Must be.txt!"); }
                }
                else
                {  AddError(1, "Invalid file format. Must be .txt"); }
            }
            else { AddError(0, "The file doesn't exist!"); }
        }

        public void SetErrors()
        {
            Errors = new string[3];
            for(int i = 0; i < 3; i++)
            {
                Errors[i] = "";
            }
        }

        public void AddError(int num, string message)
        {
            Errors[num] = message;
        }

        public char[,] GetMap()
        {
            char[,] map = MapArray;
            return map;
        }

    }
}
