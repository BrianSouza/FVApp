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
            var parceiros = _PNDados.RetornarParceiros();

            if (string.IsNullOrEmpty(Filtro))
                return parceiros;
            else
            {
                var pnFiltrado = parceiros.Where(t0 => t0.CardName.StartsWith(Filtro));
                return new ObservableCollection<Parceiro>(pnFiltrado);
            }

        }
    }
}
