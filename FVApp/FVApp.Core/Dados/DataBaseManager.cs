using System;
using System.Collections.ObjectModel;
using System.Linq;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using MvvmCross.Platform;

namespace FVApp.Core.Dados
{
    public class DataBaseManager :IDisposable , IDataBaseManager
    {
        public SQLite.Net.SQLiteConnection _conexao;
        public DataBaseManager()
        {
            var config = Mvx.Resolve<IConfigDados>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "FVAppDB.db3"));
            CriarTabelas();
        }

        public int Insert<T>(T tabela)
        {
            int count = _conexao.Insert(tabela);
            return count;
        }

        public int Insert<T>(ObservableCollection<T> tabela)
        {
            int count = _conexao.InsertAll(tabela, true);
            return count;
        }

        public int Update<T>(T tabela)
        {
            int count = _conexao.Update(tabela);
            return count;
        }
        public int Delete<T>(T tabela)
        {
            int count = _conexao.Delete(tabela);
            return count;
        }

        public void CriarTabelas()
        {
            _conexao.CreateTable<Parceiro>();

        }

        public ObservableCollection<T> GetAll<T>() where T : class , IKeyObject,new()
        {
            return new ObservableCollection<T>(_conexao.Table<T>().AsEnumerable<T>().ToList());
        }

        public T GetItem<T>(string key) where T : class, IKeyObject, new()
        {
            var result = (from entry in _conexao.Table<T>().AsEnumerable<T>()
                          where entry.Key.Equals(key)
                          select entry).FirstOrDefault();

            return result;
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
