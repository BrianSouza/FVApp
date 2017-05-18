
using FVApp.Core.Entidades;
using FVApp.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;

namespace FVApp.Core.ViewModels
{
    public class ConfigViewModel : MvxViewModel
    {
        ISaveAndLoad _SaL;
        bool _AmbienteDemo;
        Config _Config;
        bool _HabilitarURL;
        public bool HabilitarURL
        {
            get { return _HabilitarURL; }
            set
            {
                SetProperty(ref _HabilitarURL, value);
            }
        }
        public bool AmbienteDemo
        {
            get { return _AmbienteDemo; }
            set
            {
                SetProperty(ref _AmbienteDemo, value);
                HabilitarURL = value == true ? false : true;
                if (value) UrlProducao = string.Empty;
            }
        }
        string _UrlProducao;
        public string UrlProducao
        {
            get { return _UrlProducao; }
            set
            {
                SetProperty(ref _UrlProducao, value);
            }
        }
        public ConfigViewModel()
        {
            _Config = new Config();
            _SaL = Mvx.Resolve<ISaveAndLoad>();
            CarregaArquivoConfig();
        }
        private void CarregaArquivoConfig()
        {
            if (_SaL.ValidateExist("FVAppConfig.txt"))
            {
                string jsonConfig = _SaL.LoadText("FVAppConfig.txt");
                _Config = JsonConvert.DeserializeObject<Config>(jsonConfig);
                AmbienteDemo = _Config.AmbienteDemo;
                UrlProducao = _Config.UrlProducao;
            }
        }
        private void SalvarTxtConfig()
        {
            _Config.AmbienteDemo = AmbienteDemo;
            _Config.UrlProducao = UrlProducao;

            if (_SaL.ValidateExist("FVAppConfig.txt"))
            {
                _SaL.ExcludeFile("FVAppConfig.txt");
            }

            string config = JsonConvert.SerializeObject(_Config);
            _SaL.SaveText("FVAppConfig.txt", config);

            ShowViewModel<LoginViewModel>();
        }
        private bool ValidaArquivoConfig()
        {
            bool existeArquivoConfig = _SaL.ValidateExist("FVAppConfig.txt");
            if (AmbienteDemo && existeArquivoConfig)
                return true;

            else if ((!AmbienteDemo && string.IsNullOrEmpty(UrlProducao)) || !existeArquivoConfig)
                return false;

            else if ((!AmbienteDemo && !string.IsNullOrEmpty(UrlProducao)) && existeArquivoConfig)
                return true;
            else
                return false;
        }
        public IMvxCommand SalvarConfiguracao
        {
            get
            {
                return new MvxCommand(SalvarTxtConfig, ValidaArquivoConfig);
            }
        }
        public IMvxCommand Voltar
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LoginViewModel>());
            }
        }
    }
}
