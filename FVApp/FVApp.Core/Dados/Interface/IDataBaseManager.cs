using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Core.Dados.Interface
{
    interface IDataBaseManager
    {
        int Insert<T>(T tabela);

        int Update<T>(T tabela);

        int Delete<T>(T tabela);

        void CriarTabelas();

        ObservableCollection<T> GetAll<T>() where T : class, IKeyObject, new();

        T GetItem<T>(string key) where T : class, IKeyObject, new();
    }
}
