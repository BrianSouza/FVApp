using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;
using MvvmCross.Plugins.Validation.Droid;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Dados;
using FVApp.Droid.Dados;

namespace FVApp.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.RegisterType<IMvxToastService>(() => new MvxAndroidToastService(ApplicationContext));
            Mvx.RegisterType<IConfigDados>(() => new ConfigDados());
            Mvx.RegisterType<IDataBaseManager, DataBaseManager>();
            Mvx.RegisterType<IParceirosDados, ParceirosDados>();
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
