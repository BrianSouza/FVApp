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
        bool Salvo = false;

        public Ped Pedido
        {
            get { return _Ped; }
            set
            {
                SetProperty(ref _Ped,value);
            }
        }

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

        public MvxCommand Salvar()
        {
            return new MvxCommand(VoltarParaOMenu,Validacao);
        }

        private void VoltarParaOMenu()
        {

        }

        private bool Validacao()
        {
            bool valido = true;

            if (_Ped == null)
                valido = false;

            if (!Salvo)
                valido = false;

            if (valido)
                DeletarTxt();

            return valido;
        }

        private void DeletarTxt()
        {
            _SaL.ExcludeFile("Pedido.txt");
        }
    }
}
