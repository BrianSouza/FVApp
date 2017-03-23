using FVApp.Core.Dados;
using FVApp.Core.Dados.Interface;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Validation;

namespace FVApp.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IValidator, Validator>();
            Mvx.RegisterType<IDataBaseManager, DataBaseManager>();
            Mvx.RegisterType<IParceirosDados, ParceirosDados>();
            Mvx.RegisterType<ICondicoesPagamentoDados, CondicoesPagamentoDados>();
            Mvx.RegisterType<IFilialDados, FilialDados>();
            Mvx.RegisterType<IFormasPagamentoDados, FormasPagamentosDados>();
            Mvx.RegisterType<IItensDados, ItensDados>();



            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
