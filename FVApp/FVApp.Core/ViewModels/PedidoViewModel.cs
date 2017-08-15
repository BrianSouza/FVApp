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

        private Parceiro _Parceiro;
        public Parceiro Parceiro
        {
            get => _Parceiro;
            set => SetProperty(ref _Parceiro,value);
        }

        private ObservableCollection<Parceiro> _Parceiros;
        public ObservableCollection<Parceiro> Parceiros
        {
            get { return _Parceiros; }
            set
            {
                SetProperty(ref _Parceiros, value);
            }
        }

        private Empresa _Empresa;
        public Empresa Empresa
        {
            get => _Empresa;
            set => SetProperty(ref _Empresa, value);
        }

        private ObservableCollection<Empresa> _Empresas;
        public ObservableCollection<Empresa> Empresas
        {
            get { return _Empresas; }
            set
            {
                SetProperty(ref _Empresas, value);
            }
        }

        private string _TpPedido;
        public string TpPedido
        {
            get => _TpPedido;
            set => SetProperty(ref _TpPedido, value);
        }

        private ObservableCollection<string> _TiposPed;
        public ObservableCollection<string> TiposPed
        {
            get { return _TiposPed; }
            set
            {
                SetProperty(ref _TiposPed, value);
            }
        }


        public ICommand NavegarProximaTela
        {
            get
            {
                return new MvxCommand(IrParaItens);
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


        private bool CarregaArquivoPedido()
        {
            if (_SaL.ValidateExist("Pedido.txt"))
            {
                _Ped.CardCode = Parceiro.CardCode;
                _Ped.CardName = Parceiro.CardName;

                string jsonPedido = _SaL.LoadText("Pedido.txt");
                _Ped = JsonConvert.DeserializeObject<Ped>(jsonPedido);
                return true;
            }
            else
                return false;
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
