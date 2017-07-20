
using FVApp.Core.Dados.Interface;
using SQLite.Net.Attributes;

namespace FVApp.Core.Dados.Entidades
{
    public class Filial : IKeyObject
    {
        [PrimaryKey, AutoIncrement]

        public int Key { get; set; }

        public string RazaoSocial { get; set; }

        public string Empresa { get; set; }
    }
}
