using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;
using Newtonsoft.Json;

namespace FVApp.Core.ViewModels
{
    public class PedidoItensViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        IMvxToastService _ToastService;
        Ped _Ped = null;
        IItensDados _ItensDados;

        private ObservableCollection<Itens> _LstItens;
        public ObservableCollection<Itens> LstItens
        {
            get { return _LstItens; }
            set
            {
                SetProperty(ref _LstItens, value);
            }
        }

        private Itens _ItemSelected;
        public Itens ItemSelected
        {
            get { return _ItemSelected; }
            set
            {
                SetProperty(ref _ItemSelected, value);
            }
        }

        private double _Quantidade;
        public double Quantidade
        {
            get { return _Quantidade; }
            set
            {
                SetProperty(ref _Quantidade, value);
            }
        }

        private double _Valor;
        public double Valor
        {
            get { return _Valor; }
            set
            {
                SetProperty(ref _Valor, value);
            }
        }

        private ObservableCollection<PedItens> _ItensAdicionados;
        public ObservableCollection<PedItens> ItensAdicionados
        {
            get { return _ItensAdicionados; }
            set
            {
                this.SetProperty(ref _ItensAdicionados, value);
            }
        }

        public PedidoItensViewModel()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            _ToastService = Mvx.Resolve<IMvxToastService>();
            _ItensDados = Mvx.Resolve<IItensDados>();
            CarregaArquivoPedido();
        }
        public void CarregarListaItens()
        {
            LstItens = _ItensDados.RetornarItens();
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
        private void SalvarTxtPedido()
        {
            _Ped.PItens = ItensAdicionados;
            string ped = JsonConvert.SerializeObject(_Ped);
            _SaL.SaveText("Pedido.txt", ped);
        }

        public ICommand NavegarProximaTela
        {
            get
            {
                return new MvxCommand(IrParaFinanceiro, ValidaSeSelecionouParceiro);
            }
        }

        private bool ValidaSeSelecionouParceiro()
        {
            if (ItensAdicionados.Count > 0)
            {
                SalvarTxtPedido();
                return true;
            }
            else return false;
        }

        private void IrParaFinanceiro()
        {
            ShowViewModel<PedidoFinanceiroViewModel>();
        }
    }
}