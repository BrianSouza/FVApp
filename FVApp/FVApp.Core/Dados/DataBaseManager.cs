using System;
using System.Collections.ObjectModel;
using System.Linq;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Platform;
using Newtonsoft.Json;

namespace FVApp.Core.Dados
{
    public class DataBaseManager : IDisposable, IDataBaseManager
    {
        public SQLite.Net.SQLiteConnection _conexao;

        private ISaveAndLoad _SaL;

        public DataBaseManager()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            string nomeBase = string.Empty;
            nomeBase = GetNomeBase();

            var config = Mvx.Resolve<IConfigDados>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, nomeBase));
            CriarTabelas();
        }

        private string GetNomeBase()
        {
            
            Config _Config = null;
            if (_SaL.ValidateExist("FVAppConfig.txt"))
            {
                string jsonConfig = _SaL.LoadText("FVAppConfig.txt");
                _Config = JsonConvert.DeserializeObject<Config>(jsonConfig);
            }
            else
            {
               _Config = CriarArquivoConfig();
            }

            if (_Config.AmbienteDemo)
                return "DEMOFVAppDB.db3";
            else
                return "FVAppDB.db3";


        }

        private Config CriarArquivoConfig()
        {
            Config config = new Config()
            {
                AmbienteDemo = true,
                UrlProducao = ""
            };

            var _Config = JsonConvert.SerializeObject(config);
            _SaL.SaveText("FVAppConfig.txt", _Config);

            return config;
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
            _conexao.CreateTable<Pedido>();

        }

        public ObservableCollection<T> GetAll<T>() where T : class, IKeyObject, new()
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
