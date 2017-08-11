
using MvvmCross.Core.ViewModels;

namespace FVApp.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        public MenuViewModel()
        {

        }

        public MvxCommand NavegarParaPedidos
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<PedidosViewModel>());
            }
        }

        public MvxCommand NavegarParaParceiros
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ParceirosViewModel>());
            }
        }

        public MvxCommand NavegarParaSync
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SyncViewModel>());
            }
        }

    }
}
