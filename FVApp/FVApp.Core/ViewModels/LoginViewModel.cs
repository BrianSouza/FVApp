using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace FVApp.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public LoginViewModel()
        {

        }

        private string _Usuario;
        public string Usuario
        {
            get { return _Usuario; }
            set
            {
                this.SetProperty(ref _Usuario, value);
            }
        }

        private string _Senha;
        public string Senha
        {
            get { return _Senha; }
            set
            {
                this.SetProperty(ref _Senha, value);
            }
        }

        public IMvxCommand Login
        {
            get
            {
                return new MvxCommand(Logar,ValidaLogin);
            }
        }

        private void Logar()
        {
            ShowViewModel<MenuViewModel>();
        }

        private bool ValidaLogin()
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Senha))
            {
                return false;
            }
            else
                return true;
        }
    }
}
