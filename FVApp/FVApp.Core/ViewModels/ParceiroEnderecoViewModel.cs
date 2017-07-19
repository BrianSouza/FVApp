using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Core.ViewModels
{
    public class ParceiroEnderecoViewModel : MvxViewModel
    {
        IMvxToastService toastService;
        IValidator validator;
        public Parceiro pn;
        public ParceiroEnderecoViewModel()
        {
            this.toastService = Mvx.Resolve<IMvxToastService>();
            this.validator = Mvx.Resolve<IValidator>();

            Estados = new ObservableCollection<string>
            {
                "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA","MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN","RS","RO","RR","SC","SP","SE","TO"
            };
        }

        public void Init(Parceiro _pn)
        {
            pn = _pn;
            LoadSelectedParceiro();
        }

        private void LoadSelectedParceiro()
        {
            if (!string.IsNullOrEmpty(pn.Endereco))
            {
                Endereco = pn.Endereco;
                Numero = pn.Numero;
                Complemento = pn.Complemento;
                Bairro = pn.Bairro;
                Cidade = pn.Cidade;
                Estado = pn.Estado;
                CEP = pn.CEP;
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

        private Parceiro GetParceiro()
        {
            if (pn != null)
            {
                pn.Bairro = this.Bairro;
                pn.CEP = this.CEP;
                pn.Cidade = this.Cidade;
                pn.Complemento = this.Complemento;
                pn.Endereco = this.Endereco;
                pn.Estado = this.Estado;
                pn.Numero = this.Numero;
            }
            return pn;
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
            ShowViewModel<ParceiroContatoViewModel>(pn);
        }

        public IMvxCommand Voltar
        {
            get;
            private set;
        }

        public void Back()
        {
            ShowViewModel<ParceiroViewModel>();
        }
    }
}
