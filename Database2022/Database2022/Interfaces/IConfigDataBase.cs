using System;
using System.Collections.Generic;
using System.Text;

namespace Database2022
{
    public interface IConfigDataBase
    {
        string GetFullPath(string databaseFileName);
    }
}
