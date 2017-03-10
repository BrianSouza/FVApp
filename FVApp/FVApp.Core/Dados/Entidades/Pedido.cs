
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class Pedido : IKeyObject
    {
        public string Key { get; set; }

        public string CardCode { get; set;}

        public string CardName { get; set; }

        public double ValorTotal { get; set; }

        public string FormarPagamento { get; set; }

        public string CondicaoPagamento { get; set; }

    }
}
