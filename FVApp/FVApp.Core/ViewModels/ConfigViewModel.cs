
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

        public bool AmbienteDemo
        {
            get { return _AmbienteDemo; }
            set
            {
                SetProperty(ref _AmbienteDemo, value);
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
            _SaL = Mvx.Resolve<ISaveAndLoad>();
        }
        private bool CarregaArquivoConfig()
        {
            if (_SaL.ValidateExist("FVAppConfig.txt"))
            {
                string jsonConfig = _SaL.LoadText("FVAppConfig.txt");
                _Config = JsonConvert.DeserializeObject<Config>(jsonConfig);
                return true;
            }
            else
                return false;
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

        public IMvxCommand SalvarConfiguracao()
        {
            return new MvxCommand(SalvarTxtConfig,ValidaArquivoConfig);
        }

        

    }
}
