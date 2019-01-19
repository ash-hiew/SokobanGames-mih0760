namespace FileHandlerNS
{
    public interface ISaver
    {
        void SaveMap(string name);
        void SetMap(char[,] map);
    }
}