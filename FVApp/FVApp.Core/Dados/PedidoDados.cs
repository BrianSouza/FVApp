using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados
{
    public class PedidoDados : BaseDados, IPedidosDados
    {
        public bool DeletarPedidos(Pedido ped)
        {
            if (dbmService.Delete<Pedido>(ped) > 0)
                return true;
            else
                return false;
        }

        public ObservableCollection<Pedido> RetornarPedidos()
        {
            return dbmService.GetAll<Pedido>();
        }

        public Pedido RetornarPedidos(string id)
        {
            return dbmService.GetItem<Pedido>(id);
        }

        public bool SalvarPedidos(Pedido ped)
        {
            if (ped.Key > 0)
            {
                if (dbmService.Insert<Pedido>(ped) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<Pedido>(ped) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
