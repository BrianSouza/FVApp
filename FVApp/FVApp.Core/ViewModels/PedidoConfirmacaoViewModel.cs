using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;

namespace FVApp.Core.ViewModels
{
    public class PedidoConfirmacaoViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        Ped _Ped;

        public PedidoConfirmacaoViewModel()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();

        }

        public bool CarregaArquivoPedido()
        {
            if (_SaL.ValidateExist("Pedido.txt"))
            {
                string jsonPedido = _SaL.LoadText("Pedido.txt");
                _Ped = JsonConvert.DeserializeObject<Ped>(jsonPedido);
                return true;
            }
            else
                return false;
        }
    }
}
