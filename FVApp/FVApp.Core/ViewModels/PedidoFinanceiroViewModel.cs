
using System.Collections.ObjectModel;
using System.Windows.Input;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation.ForFieldBinding;
using Newtonsoft.Json;

namespace FVApp.Core.ViewModels
{
    public class PedidoFinanceiroViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        Ped _Ped;
        ICondicoesPagamentoDados cpDados;
        IFormasPagamentoDados fpDados;
        public PedidoFinanceiroViewModel()
        {
            cpDados = Mvx.Resolve<ICondicoesPagamentoDados>();
            fpDados = Mvx.Resolve<IFormasPagamentoDados>();
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            CarregarCondPagto();
            CarregarFormPgto();
            CarregaArquivoPedido();
        }

        public ICommand NavegarProximaTela
        {
            get
            {
                return new MvxCommand(IrParaPaginaConfirmacao,Validacao);
            }
        }

        private void IrParaPaginaConfirmacao()
        {
            SalvarTxtPedido();
            ShowViewModel<PedidoFinanceiroViewModel>();
        }

        private bool Validacao()
        {
            if (CPSelected == null || FPSelected == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        ObservableCollection<CondPagto> _LstCP;
        public ObservableCollection<CondPagto> LstCP
        {
            get { return _LstCP; }
            set
            {
                SetProperty(ref _LstCP, value);
            }
        }

        ObservableCollection<FormPgto> _LstFP;
        public ObservableCollection<FormPgto> LstFP
        {
            get { return _LstFP; }
            set
            {
                SetProperty(ref _LstFP, value);
            }
        }

        [NCFieldRequired("Selecione uma condição de pagamento")]
        public INC<CondPagto> CPSelected = new NC<CondPagto>();

        [NCFieldRequired("Selecione uma forma de pagamento")]
        public INC<FormPgto> FPSelected = new NC<FormPgto>();
        //CondPagto _CPSelected;
        //public CondPagto CPSelected
        //{
        //    get
        //    {
        //        return _CPSelected;
        //    }

        //    set
        //    {
        //        SetProperty(ref _CPSelected, value);
        //    }
        //}

        //FormPgto _FPSelected;
        //public FormPgto FPSelected
        //{
        //    get { return _FPSelected; }
        //    set
        //    {
        //        SetProperty(ref _FPSelected,value);
        //    }
        //}

        private void CarregarFormPgto()
        {
            var fps = fpDados.RetornarFormasPagamento();

            foreach (var item in fps)
            {
                FormPgto FP = new FormPgto();
                FP.Code = item.Code;
                FP.Descricao = item.Descricao;
                LstFP.Add(FP);
            }
        }

        private void CarregarCondPagto()
        {
            

            var cps = cpDados.RetornarCondicoes();

            foreach (var item in cps)
            {
                CondPagto cp = new CondPagto();
                cp.Code = item.Code;
                cp.Descricao = item.Descricao;
                LstCP.Add(cp);
            }
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
            _Ped.CP = CPSelected.Value;
            _Ped.FP = FPSelected.Value;
            string ped = JsonConvert.SerializeObject(_Ped);
            _SaL.SaveText("Pedido.txt", ped);
        }

    }
}
