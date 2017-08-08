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
using MvvmCross.Plugins.Visibility;

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

        private bool _Cliente;
        public bool Cliente
        {
            get
            {
                return _Cliente ;
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
        public Parceiro pn;
        public ParceiroViewModel()
        {
            this.toastService = Mvx.Resolve<IMvxToastService>();
            this.validator = Mvx.Resolve<IValidator>();
        }

        private Parceiro GetParceiro()
        {
            if (pn == null)
                pn = new Parceiro();

            pn.CardCode = this.CardCode;
            pn.CardName = this.CardName;
            pn.Empresa = this.Empresa;
            pn.TipoParceiro = this.TipoParceiro;
            pn.TipoDocumento = this.TipoDocumento;
            pn.Documento = this.Documento;

            if (string.IsNullOrEmpty(pn.CardCode))
                pn.PossuiCodigoSAP = false;
            else
                pn.PossuiCodigoSAP = true;


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
                Empresa = pn.Empresa;
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

        public override void Start()
        {
            NavegarFwd = new MvxCommand(Next);
            Voltar = new MvxCommand(Back);
        }

        public IMvxCommand NavegarFwd
        {
            get;
            private set;
        }

        public void Next()
        {
            pn = GetParceiro();
            if (ValidaCampos())
                ShowViewModel<ParceiroEnderecoViewModel>(pn);
        }
        public IMvxCommand Voltar
        {
            get;
            private set;
        }

        public void Back()
        {
            ShowViewModel<ParceirosViewModel>();
        }

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(pn.CardName))
            {
                toastService.DisplayError("Informe a razão social.");
                return false;
            }
            else if (string.IsNullOrEmpty(pn.TipoParceiro))
            {
                toastService.DisplayError("Informe o tipo do parceiro.");
                return false;
            }
            else if (string.IsNullOrEmpty(pn.TipoDocumento))
            {
                toastService.DisplayError("Informe o tipo de documento.");
                return false;
            }
            else if (string.IsNullOrEmpty(pn.Documento) || (pn.Documento.Length < 11))
            {
                toastService.DisplayError("Informe o número do documento.");
                return false;
            }
            return true;
        }

    }
}
