using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FVApp.Core.Dados;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;
using MvvmCross.Plugins.Validation.ForFieldBinding;
using System.Collections.ObjectModel;

namespace FVApp.Core.ViewModels
{
    public class ParceiroViewModel : MvxViewModel
    {
        private int _IdMobile;
        public int IdMobile
        {
            get { return _IdMobile; }
            set
            {
                SetProperty(ref _IdMobile, value);
            }
        }

        private string _CardCode;
        public string CardCode
        {
            get { return _CardCode; }
            set
            {
                SetProperty(ref _CardCode, value);
            }
        }
        [NCFieldRequired("Informe a razão social.")]
        public INC<string> CardName = new NC<string>();

        [NCFieldRequired("Informe o endereço.")]
        public INC<string> Endereco = new NC<string>();

        [NCFieldRequired("Informe o número.")]
        public INC<string> Numero = new NC<string>();

        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { SetProperty(ref _Complemento, value); }
        }

        [NCFieldRequired("Informe o bairro.")]
        public INC<string> Bairro = new NC<string>();

        [NCFieldRequired("Informe a cidade.")]
        public INC<string> Cidade = new NC<string>();

        [NCFieldRequired("Informe o estado.")]
        public INC<string> Estado = new NC<string>();

        private ObservableCollection<string> _Estados;
        public ObservableCollection<string> Estados
        {
            get { return _Estados; }
            set
            {
                SetProperty(ref _Estados, value);
            }
        }

        [NCFieldRequired("Informe o CEP.")]
        public INC<string> CEP = new NC<string>();

        [NCFieldRequired("Informe a Empresa.")]
        public INC<string> Empresa = new NC<string>();

        [NCFieldRequired("Informe o CNPJ ou CPF.")]
        public INC<string> Documento = new NC<string>();

        [NCFieldRequired("Informe o tipo de documento.")]
        public INC<string> TipoDocumento = new NC<string>();

        [NCFieldRequired("Informe o tipo do Parceiro.")]
        public INC<string> TipoParceiro = new NC<string>();

        private string _NomeContato;
        public string NomeContato
        {
            get { return _Telefone; }
            set { SetProperty(ref _NomeContato, value); }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { SetProperty(ref _Telefone, value); }
        }

        private bool _Cliente;
        public bool Cliente
        {
            get
            {
                return _Cliente;
            }
            set
            {
                SetProperty(ref _Cliente, value);
            }
        }
        private bool _Fornecedor;
        public bool Fornecedor
        {
            get
            {
                return _Fornecedor;
            }
            set
            {
                SetProperty(ref _Fornecedor, value);
            }
        }

        private bool _CPF;
        public bool CPF
        {
            get { return _CPF; }
            set
            {
                SetProperty(ref _CPF, value);
            }
        }
        private bool _CNPJ;
        public bool CNPJ
        {
            get { return _CNPJ; }
            set
            {
                SetProperty(ref _CNPJ, value);
            }
        }

        IMvxToastService toastService;
        IValidator validator;
        IParceirosDados pnService;
        public Parceiro pn;
        public ParceiroViewModel()
        {
            this.toastService = Mvx.Resolve<IMvxToastService>();
            this.validator = Mvx.Resolve<IValidator>();
            this.pnService = Mvx.Resolve<IParceirosDados>();
        }
        

        public override void Start()
        {
            Salvar = new MvxCommand(SalvarParceiro);
        }

        public IMvxCommand Salvar
        {
            get;
            private set;
        }

        public void SalvarParceiro()
        {
            if (pn == null)
                pn = GetParceiro();

            pnService.SalvarParceiro(pn);
        }

        private Parceiro GetParceiro()
        {
            pn = new Parceiro
            {
                CardCode = this.CardCode,
                CardName = this.CardName.ToString(),
                Bairro = this.Bairro.ToString(),
                CEP = this.CEP.ToString(),
                Cidade = this.Cidade.ToString(),
                Complemento = this.Complemento,
                //TODO: definir como receber empresa
                Empresa = this.Empresa.ToString(),
                Endereco = this.Endereco.ToString(),
                Estado = this.Estado.ToString(),
                Numero = this.Numero.ToString(),
                Telefone = this.Telefone

            };

            return pn;
        }
    }
}
