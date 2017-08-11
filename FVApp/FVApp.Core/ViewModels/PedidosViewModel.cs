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
    public class PedidosViewModel : MvxViewModel
    {
         private IPedidosDados _PedDados;
        public PedidosViewModel()
        {
            _PedDados = Mvx.Resolve<IPedidosDados>();
            GetPedidos();
        }

        private Pedido _SelectedPedido;
        public Pedido SelectedPedido
        {
            get
            {
                return _SelectedPedido;
            }
            set
            {
                SetProperty(ref _SelectedPedido, value);
                if (_SelectedPedido != null)
                    ShowViewModel<ViewModels.ParceiroViewModel>(_SelectedPedido);

            }
        }

        private ObservableCollection<Pedido> _ListaPedidos;
        public ObservableCollection<Pedido> ListaPedidos
        {
            get
            {
                return _ListaPedidos;
            }
            set
            {
                SetProperty(ref _ListaPedidos, value);
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

        private ObservableCollection<Pedido> GetPedidos()
        {
            ListaPedidos = _PedDados.RetornarPedidos();

            if (string.IsNullOrEmpty(Filtro))
                return ListaPedidos;
            else
            {
                var pedFiltrado = ListaPedidos.Where(t0 => t0.CardName.StartsWith(Filtro));
                return new ObservableCollection<Pedido>(pedFiltrado);
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
                return new MvxCommand(() => ShowViewModel<ViewModels.PedidoViewModel>());
            }
        }
  
    }
}
