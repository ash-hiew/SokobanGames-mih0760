namespace FileHandlerNS
{
    public interface IFiler
    {
        string[] Errors { get; set; }

        void SaveMap(string name);
        void LoadFile(string fileName);
        char[,] GetMap();
        void SetMap(char[,] map);
        void CreateSaveFolder();
        string GetSaveLocation();

        string GetMapString();
        void Compress();
    }
}
