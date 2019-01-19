using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlerNS
{
    public enum Parts
    {
        Wall = (char)'#',
        Empty = (char)'-',
        Player = (char)'@',
        Goal = (char)'.',
        Block = (char)'$',
        BlockOnGoal = (char)'*',
        PlayerOnGoal = (char)'+'
    }

    public interface IFileable
    {
        Parts WhatsAt(int row, int column);
        int GetColumnCount();
        int GetRowCount();
        void Save(string filename, IFileable callMeBackforDetails);
        string Load(string filename);
    }
}
