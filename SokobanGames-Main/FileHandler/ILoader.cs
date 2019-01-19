namespace FileHandlerNS
{
    public interface ILoader
    {
        void LoadFile(string fileName);
        char[,] GetMap();
    }
}

