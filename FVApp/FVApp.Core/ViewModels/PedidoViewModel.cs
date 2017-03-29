using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;
using MvvmCross.Plugins.Validation.ForFieldBinding;
using Newtonsoft.Json;

namespace FVApp.Core.ViewModels
{
    public class PedidoViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        IMvxToastService toastService;
        Ped _Ped = null;

        public PedidoViewModel()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            toastService = Mvx.Resolve<IMvxToastService>();
            CarregaArquivoPedido();
        }

        private int _DocEntry;
        public int DocEntry
        {
            get { return _DocEntry; }
            set
            {
                _DocEntry = value;
                SetProperty(ref _DocEntry, value);
            }
        }

        [NCFieldRequired("Selecione um parceiro.")]
        public INC<string> CardCode = new NC<string>();

        [NCFieldRequired("Selecione um parceiro.")]
        public INC<string> CardName = new NC<string>();

        public ICommand NavegarProximaTela
        {
            get
            {
                return new MvxCommand(IrParaItens,ValidaSeSelecionouParceiro);
            }
        }

        private void IrParaItens()
        {
            try
            {
                SalvarTxtPedido();
                ShowViewModel<PedidoItensViewModel>();
            }
            catch (Exception e)
            {
                toastService.DisplayError(e.Message);
            }
            
        }

        private bool ValidaSeSelecionouParceiro()
        {
            if (!string.IsNullOrEmpty(CardCode.ToString()) || !string.IsNullOrEmpty(CardName.ToString()))
            {
                return true;
            }
            else return false;
        }

        private void CarregaArquivoPedido()
        {
            if(_SaL.ValidateExist("Pedido.txt"))
            {
                string jsonPedido = _SaL.LoadText("Pedido.txt");
                _Ped = JsonConvert.DeserializeObject<Ped>(jsonPedido);
            }
        }

        private void SalvarTxtPedido()
        {
            string ped = JsonConvert.SerializeObject(_Ped);
            _SaL.SaveText("Pedido.txt", ped);
        }
    }
}
