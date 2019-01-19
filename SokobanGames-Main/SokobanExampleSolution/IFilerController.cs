using System;
using System.Windows.Forms;
using FileHandlerNS;
using GameNS;

namespace Sokoban
{
    interface IFilerController
    {

        Form Start();
        void ShowForm();
        void Ex_Save(char[,] map);
        void Ex_Load();
        //void game_save(string filename, IFileable callMeBackforDetails);
        string game_load(string filename);
        Tuple<string, string, string> game_state_load(string filename);

        void OnFileEvent(object sender, FilerForm.FileEventArgs e);
        char[,] ReturnMap();
        string ArrayToString(char[,] map);

    }
}
