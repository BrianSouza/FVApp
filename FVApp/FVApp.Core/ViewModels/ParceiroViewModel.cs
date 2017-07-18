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

        private string _CardName;
        public string CardName
        {
            get { return _CardName; }
            set
            {
                SetProperty(ref _CardName, value);
            }
        }

        private string _Endereco;
        public string Endereco
        {
            get { return _Endereco; }
            set
            {
                SetProperty(ref _Endereco, value);
            }
        }

        private string _Numero;
        public string Numero
        {
            get { return _Numero; }
            set
            {
                SetProperty(ref _Numero, value);
            }
        }


        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { SetProperty(ref _Complemento, value); }
        }

        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set
            {
                SetProperty(ref _Bairro, value);
            }
        }

        private string _Cidade;
        public string Cidade
        {
            get { return _Cidade; }
            set
            {
                SetProperty(ref _Cidade, value);
            }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set
            {
                SetProperty(ref _Estado, value);
            }
        }

        private ObservableCollection<string> _Estados;
        public ObservableCollection<string> Estados
        {
            get { return _Estados; }
            set
            {
                SetProperty(ref _Estados, value);
            }
        }

        private string _Empresa;
        public string Empresa
        {
            get { return _Empresa; }
            set
            {
                SetProperty(ref _Empresa, value);
            }
        }
        private ObservableCollection<string> _Empresas;
        public ObservableCollection<string> Empresas
        {
            get { return _Empresas; }
            set
            {
                SetProperty(ref _Empresas, value);
            }
        }
        private string _CEP;
        public string CEP
        {
            get { return _CEP; }
            set
            {
                SetProperty(ref _CEP, value);
            }
        }


        private string _Documento;
        public string Documento
        {
            get { return _Documento; }
            set
            {
                SetProperty(ref _Documento, value);
            }
        }

        private string _TipoDocumento;
        public string TipoDocumento
        {
            get { return _TipoDocumento; }
            set
            {
                SetProperty(ref _TipoDocumento, value);
            }
        }

        private string _TipoParceiro;
        public string TipoParceiro
        {
            get { return _TipoParceiro; }
            set
            {
                SetProperty(ref _TipoParceiro, value);
            }
        }

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
                if (value)
                {
                    Fornecedor = false;
                    TipoParceiro = "C";
                }
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
                if (value)
                {
                    Cliente = false;
                    TipoParceiro = "S";
                }
            }
        }

        private bool _CPF;
        public bool CPF
        {
            get { return _CPF; }
            set
            {
                SetProperty(ref _CPF, value);
                if (value)
                {
                    CNPJ = false;
                    TipoDocumento = "CPF";
                }
            }
        }
        private bool _CNPJ;
        public bool CNPJ
        {
            get { return _CNPJ; }
            set
            {
                SetProperty(ref _CNPJ, value);
                if (value)
                {
                    CPF = false;
                    TipoDocumento = "CNPJ";
                }
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

            Estados = new ObservableCollection<string>
            {
                "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA","MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN","RS","RO","RR","SC","SP","SE","TO"
            };
        }

        public ParceiroViewModel(Parceiro pn)
        {
            this.toastService = Mvx.Resolve<IMvxToastService>();
            this.validator = Mvx.Resolve<IValidator>();
            this.pnService = Mvx.Resolve<IParceirosDados>();

            Estados = new ObservableCollection<string>
            {
                "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA","MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN","RS","RO","RR","SC","SP","SE","TO"
            };
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
            //if (pn == null)
            pn = GetParceiro();

            pnService.SalvarParceiro(pn);
        }

        private Parceiro GetParceiro()
        {

            pn = new Parceiro();

            pn.CardCode = this.CardCode;
            pn.CardName = this.CardName;
            pn.Bairro = this.Bairro;
            pn.CEP = this.CEP;
            pn.Cidade = this.Cidade;
            pn.Complemento = this.Complemento;
            //TODO: definir como receber empresa
            pn.Empresa = this.Empresa;
            pn.Endereco = this.Endereco;
            pn.Estado = this.Estado;
            pn.Numero = this.Numero;
            pn.Telefone = this.Telefone;
            pn.TipoParceiro = this.TipoParceiro;
            pn.TipoDocumento = this.TipoDocumento;
            pn.Documento = this.Documento;
            pn.NomeContato = this.NomeContato;

            return pn;
        }
        public void Init(Parceiro _pn)
        {
            pn = _pn;
            LoadSelectedParceiro();
        }

        private void LoadSelectedParceiro()
        {
            if (pn.CardName != null)
            {
                CardCode = pn.CardCode;
                CardName = pn.CardName;
                Bairro = pn.Bairro;
                CEP = pn.CEP;
                Cidade = pn.Cidade;
                Complemento = pn.Complemento;
                Empresa = pn.Empresa;
                Endereco = pn.Endereco;
                Estado = pn.Estado;
                Numero = pn.Numero;
                Telefone = pn.Telefone;
                NomeContato = pn.NomeContato;
                Documento = pn.Documento;

                if (pn.TipoDocumento == "CPF")
                {
                    TipoDocumento = "CPF";
                    CPF = true;
                    CNPJ = false;
                }
                else if (pn.TipoDocumento == "CNPJ")
                {
                    TipoDocumento = "CNPJ";
                    CPF = false;
                    CNPJ = true;
                }

                if (pn.TipoParceiro == "S")
                {
                    TipoParceiro = pn.TipoParceiro;
                    Cliente = false;
                    Fornecedor = true;
                }
                else if (pn.TipoParceiro == "C")
                {
                    TipoParceiro = pn.TipoParceiro;
                    Cliente = true;
                    Fornecedor = false;
                }
            }
        }
    }
}
