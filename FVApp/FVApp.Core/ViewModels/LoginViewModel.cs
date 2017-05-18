using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        
        public LoginViewModel()
        {
            _SaL = Mvx.Resolve<ISaveAndLoad>();
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
                return new MvxCommand(Logar);
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

        public IMvxCommand Config
        {
            get
            {
                return new MvxCommand(() =>  ShowViewModel<ConfigViewModel>());
            }
        }
    }
}
