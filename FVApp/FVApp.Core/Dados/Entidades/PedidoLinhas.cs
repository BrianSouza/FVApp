
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class PedidoLinhas : IKeyObject
    {
        public string Key { get; set; }

        public string KeyPedido { get; set; }

        public string KeyItem { get; set; }

        public string ItemDescricao { get; set; }

        public double Quantidade { get; set; }

        public double ValorUnitario { get; set; }
        
    }
}
