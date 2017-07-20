
using FVApp.Core.Dados.Interface;
using SQLite.Net.Attributes;

namespace FVApp.Core.Dados.Entidades
{
    public class Itens : IKeyObject
    {
        [PrimaryKey, AutoIncrement]

        public int Key { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public double PrecoUnit { get; set; }

        public string Empresa { get; set; }

    }
}
