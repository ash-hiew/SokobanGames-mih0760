using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlerNS
{
    public interface IValidator
    {

        bool CheckValidSymbol(char check);
        bool CheckValidString(string check);
        bool CheckIfFileExists(string name);
        bool CheckValidFileFormat(string name);
    }
}
