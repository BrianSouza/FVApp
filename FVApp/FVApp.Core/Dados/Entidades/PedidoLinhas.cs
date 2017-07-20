
using FVApp.Core.Dados.Interface;
using SQLite.Net.Attributes;

namespace FVApp.Core.Dados.Entidades
{
    public class PedidoLinhas : IKeyObject
    {
        [PrimaryKey, AutoIncrement]

        public int Key { get; set; }

        public string KeyPedido { get; set; }

        public string KeyItem { get; set; }

        public string ItemDescricao { get; set; }

        public double Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        public double ValorTotal { get; set; }
        
    }
}
