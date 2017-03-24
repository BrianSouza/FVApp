using System;
using System.Collections.ObjectModel;
using System.Linq;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados
{
    public class PedidosLinhasDados : BaseDados, IPedidosLinhasDados
    {
        public bool DeletarLinhaPedido(PedidoLinhas linha)
        {
            if (dbmService.Delete<PedidoLinhas>(linha) > 0)
                return true;
            else
                return false;
        }

        public ObservableCollection<PedidoLinhas> RetornarLinhasPedidos(string pedido)
        {
            var allLines = RetornarPedidos();
            var linhasPedido = allLines.Where(T0 => T0.KeyPedido.Equals(pedido)).ToList();
            ObservableCollection<PedidoLinhas> linhas = new ObservableCollection<PedidoLinhas>(linhasPedido);
            return linhas;
        }

        public ObservableCollection<PedidoLinhas> RetornarPedidos()
        {
            return dbmService.GetAll<PedidoLinhas>();

        }

        public bool SalvarLinhasPedidos(Collection<PedidoLinhas> linhas)
        {
           
            if (string.IsNullOrEmpty(linhas[0].Key))
            {
                if (dbmService.Insert<Collection<PedidoLinhas>>(linhas) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<Collection<PedidoLinhas>>(linhas) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
