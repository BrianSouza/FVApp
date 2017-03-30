using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Services;
using FVApp.Core.ViewModels;
using Moq;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Validation;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace FVApp.Core.Testes
{
    [TestFixture]
    public class PedidoViewModelTestes : MvxIoCSupportingTest
    {
        Mock<PedidoViewModel> pedDados;
        Pedido ped;
        PedidoViewModel pnVM;
        protected MockDispatcher MockDispatcher { get; private set; }

        [SetUp]
        protected override void AdditionalSetup()
        {
            //base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);

            var validationService = new Mock<IValidator>();
            var configService = new Mock<IConfigDados>();
            var dbmService = new Mock<IDataBaseManager>();
            var parceiroService = new Mock<IPedidosDados>();
            var salService = new Mock<ISaveAndLoad>();

            Ioc.RegisterSingleton<IValidator>(validationService.Object);
            Ioc.RegisterSingleton<IConfigDados>(configService.Object);
            Ioc.RegisterSingleton<IDataBaseManager>(dbmService.Object);
            Ioc.RegisterSingleton<IPedidosDados>(parceiroService.Object);
            Ioc.RegisterSingleton<ISaveAndLoad>(salService.Object);
        }

        [Test]
        public void Testando_Salvar_txt()
        {

        }
    }
}
