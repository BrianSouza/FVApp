using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    public interface IPedidosDados
    {
        bool SalvarPedidos(Pedido ped);

        bool DeletarPedidos(Pedido ped);

        Pedido RetornarPedidos(string id);

        ObservableCollection<Pedido> RetornarPedidos();
    }
}
