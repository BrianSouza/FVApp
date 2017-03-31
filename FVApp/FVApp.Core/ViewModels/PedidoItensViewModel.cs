using System;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;

namespace FVApp.Core.ViewModels
{
    public class PedidoItensViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        IMvxToastService _ToastService;
        Ped _Ped = null;
        IParceirosDados _pnDados;

        public PedidoItensViewModel()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            _ToastService = Mvx.Resolve<IMvxToastService>();
            _pnDados = Mvx.Resolve<IParceirosDados>();
            CarregaArquivoPedido();
        }

        private void CarregaArquivoPedido()
        {
            throw new NotImplementedException();
        }
    }
}