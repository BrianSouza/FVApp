using FVApp.Core.Dados.Entidades;
using MvvmCross.Core.ViewModels;
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
        public ParceirosViewModel()
        {

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

       
    }
}
