using FVApp.Core.Dados;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Core.ViewModels
{
    public class ParceirosViewModel : MvxViewModel
    {
        private IParceirosDados _PNDados;
        public ParceirosViewModel()
        {
            _PNDados = Mvx.Resolve<IParceirosDados>();
            GetParceiros();
        }

        private Parceiro _SelectedParceiro;
        public Parceiro SelectedParceiro
        {
            get
            {
                return _SelectedParceiro;
            }
            set
            {
                SetProperty(ref _SelectedParceiro, value);
                if (_SelectedParceiro != null)
                    ShowViewModel<ViewModels.ParceiroViewModel>(SelectedParceiro);

            }
        }

        private ObservableCollection<Parceiro> _ListaParceiros;
        public ObservableCollection<Parceiro> ListaParceiros
        {
            get
            {
                return _ListaParceiros;
            }
            set
            {
                SetProperty(ref _ListaParceiros, value);
            }
        }

        private string _Filtro;
        public string Filtro
        {
            get
            {
                return _Filtro;
            }
            set
            {
                SetProperty(ref _Filtro, value);
            }
        }

        private ObservableCollection<Parceiro> GetParceiros()
        {
            ListaParceiros = _PNDados.RetornarParceiros();

            if (string.IsNullOrEmpty(Filtro))
                return ListaParceiros;
            else
            {
                var pnFiltrado = ListaParceiros.Where(t0 => t0.CardName.StartsWith(Filtro));
                return new ObservableCollection<Parceiro>(pnFiltrado);
            }

        }

        public MvxCommand Voltar
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ViewModels.MenuViewModel>());
            }
        }

        public MvxCommand Add
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ViewModels.ParceiroViewModel>());
            }
        }
    }
}
