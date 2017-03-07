using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

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

        private string _CardName;
        public string CardName
        {
            get { return _CardName; }
            set
            {
                SetProperty(ref _CardName, value);
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
            set { SetProperty(ref _Numero, value); }
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
            get { return _Bairro;}
            set { SetProperty(ref _Bairro, value); }
        }

        private string _Cidade;
        public string Cidade
        {
            get { return _Cidade; }
            set { SetProperty(ref _Cidade, value); }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { SetProperty(ref _Estado, value); }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { SetProperty(ref _Telefone, value); }
        }

        public ICommand  Salvar
        {
            get
            {
                return new MvxCommand(SalvarParceiro);
            }
        }

        private void SalvarParceiro()
        {

        }
    }
}
