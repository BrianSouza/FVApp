using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using SQLite.Net;

namespace FVApp.Core.Dados
{
    public class DataBaseManager
    {
        SQLiteConnection dataBase;

        public DataBaseManager()
        {
            ISQLite 
            dataBase = Mvx.Resolve()
        }
    }
}
