using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNS
{
    public interface IGameFiler
    {
        void Save(string filename, Game callMeBackforDetails);
        string Load(string filename);
        string GetSavedMoveCount();
        string GetSavedMoveHistory();
    }
}
