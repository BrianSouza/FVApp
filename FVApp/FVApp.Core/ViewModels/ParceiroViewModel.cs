using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using MvvmCross.Plugins.Validation;
using MvvmCross.Plugins.Validation.ForFieldBinding;

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

        [NCFieldRequired("Informe o CEP.")]
        public INC<string> CEP = new NC<string>();

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { SetProperty(ref _Telefone, value); }
        }

        IMvxToastService toastService;
        IValidator validator;

        public ParceiroViewModel(IValidator validator, IMvxToastService toastService)
        {
            this.toastService = toastService;
            this.validator = validator;
        }

        public override void Start()
        {
            Salvar = new MvxCommand(SalvarParceiro);
        }

        public IMvxCommand  Salvar
        {
            get;
            private set;
        }

        private void SalvarParceiro()
        {

        }
    }
}
