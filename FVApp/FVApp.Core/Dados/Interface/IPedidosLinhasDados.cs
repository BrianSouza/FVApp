using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    public interface IPedidosLinhasDados
    {
        
            bool SalvarLinhasPedidos(Collection<PedidoLinhas> linhas);

            bool DeletarLinhaPedido(PedidoLinhas linha);

            ObservableCollection<PedidoLinhas> RetornarLinhasPedidos(string pedido);

            ObservableCollection<PedidoLinhas> RetornarPedidos();
        
    }
}
