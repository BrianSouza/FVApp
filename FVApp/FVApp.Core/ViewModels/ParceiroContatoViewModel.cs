using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Core.ViewModels
{
    public class ParceiroContatoViewModel : MvxViewModel
    {
        IMvxToastService toastService;
        IValidator validator;
        IParceirosDados pnService;
        public Parceiro pn;
        public ParceiroContatoViewModel()
        {
            this.toastService = Mvx.Resolve<IMvxToastService>();
            this.validator = Mvx.Resolve<IValidator>();
            this.pnService = Mvx.Resolve<IParceirosDados>();

        }


        private string _NomeContato;
        public string NomeContato
        {
            get { return _NomeContato; }
            set { SetProperty(ref _NomeContato, value); }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { SetProperty(ref _Telefone, value); }
        }

        public void Init(Parceiro _pn)
        {
            pn = _pn;
            LoadSelectedParceiro();
        }

        private void LoadSelectedParceiro()
        {
            if (!string.IsNullOrEmpty(pn.NomeContato))
            {
                NomeContato = pn.NomeContato;
                Telefone = pn.Telefone;
            }
        }

        private Parceiro GetParceiro()
        {
            if (pn != null)
            {
                pn.Telefone = this.Telefone;

                pn.NomeContato = this.NomeContato;
            }
            return pn;
        }

        public override void Start()
        {
            Salvar = new MvxCommand(SalvarParceiro);
            Voltar = new MvxCommand(Back);

        }


        public IMvxCommand Salvar
        {
            get;
            private set;
        }

        public void SalvarParceiro()
        {
            pn = GetParceiro();

            if (pnService.SalvarParceiro(pn))
                ShowViewModel<ParceirosViewModel>();
        }
        public IMvxCommand Voltar
        {
            get;
            private set;
        }

        public void Back()
        {
            ShowViewModel<ParceiroEnderecoViewModel>();
        }

    }

}
