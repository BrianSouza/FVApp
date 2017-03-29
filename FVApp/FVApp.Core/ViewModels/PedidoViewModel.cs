using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FVApp.Core.Dados;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
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
        IMvxToastService _ToastService;
        Ped _Ped = null;
        IParceirosDados _pnDados;

        public PedidoViewModel()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            _ToastService = Mvx.Resolve<IMvxToastService>();
            _pnDados = Mvx.Resolve<IParceirosDados>();
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
        public INC<Parceiro> SelectedParceiro = new NC<Parceiro>();

        private ObservableCollection<Parceiro> _Parceiros;
        public ObservableCollection<Parceiro> Parceiros
        {
            get { return _Parceiros; }
            set
            {
                SetProperty(ref _Parceiros, value);
            }
        }

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
                _ToastService.DisplayError(e.Message);
            }
            
        }

        private bool ValidaSeSelecionouParceiro()
        {
            if (SelectedParceiro != null)
            {
                return true;
            }
            else return false;
        }

        private void CarregaArquivoPedido()
        {
            if(_SaL.ValidateExist("Pedido.txt"))
            {
                _Ped.CardCode = SelectedParceiro.Value.CardCode;
                _Ped.CardName = SelectedParceiro.Value.CardName;

                string jsonPedido = _SaL.LoadText("Pedido.txt");
                _Ped = JsonConvert.DeserializeObject<Ped>(jsonPedido);
            }
        }

        private void SalvarTxtPedido()
        {
            string ped = JsonConvert.SerializeObject(_Ped);
            _SaL.SaveText("Pedido.txt", ped);
        }

        private void CarregarParceiros()
        {
            try
            {
                Parceiros = _pnDados.RetornarParceiros();
                
            }
            catch (Exception)
            {
                _ToastService.DisplayError("Erro ao carregar parceiros de negócio.");
            }
        }
    }
}
