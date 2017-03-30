using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FVApp.Core.Dados.Interface;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.ViewModels;
using MvvmCross.FieldBinding;
using MvvmCross.Platform;
using FVApp.Core.Dados;
using MvvmCross.Plugins.Validation;
using MvvmCross.Test.Core;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;

namespace FVApp.Core.Testes
{
    [TestFixture]
    public class ParceirosTestes : MvxIoCSupportingTest
    {
        Mock<IParceirosDados> pnDados;
        Parceiro pn;
        ParceiroViewModel pnVM;
        protected MockDispatcher MockDispatcher { get; private set; }

        [SetUp]
        protected override void AdditionalSetup()
        {
            //base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);

            var validationService = new Mock<IValidator>();
            Ioc.RegisterSingleton<IValidator>(validationService.Object);
        }

        //[SetUp]
        //public void Setup()
        //{
        //    //Mvx.RegisterType<IValidator, Validator>();
        //    //Mvx.RegisterType<IDataBaseManager, DataBaseManager>();
        //    //Mvx.RegisterType<IParceirosDados, ParceirosDados>();
        //    //Mvx.RegisterType<ICondicoesPagamentoDados, CondicoesPagamentoDados>();
        //    //Mvx.RegisterType<IFilialDados, FilialDados>();
        //    //Mvx.RegisterType<IFormasPagamentoDados, FormasPagamentosDados>();
        //    //Mvx.RegisterType<IItensDados, ItensDados>();

           


        //    pnDados = new Mock<IParceirosDados>();

        //    pn = new Parceiro
        //    {
        //        CardCode = "C0001",
        //        Bairro = "Cambuci",
        //        CardName = "Brian Souza",
        //        CEP = "01521-000",
        //        Cidade = "São Paulo",
        //        Complemento = "AP 42 Bl 3",
        //        Empresa = "1",
        //        Endereco = "Cesário Ramalho",
        //        Estado = "SP",
        //        Numero = "237",
        //        Telefone = "(12)99121-0998"
        //    };
        //}

        [Test]
        public void Testando_command_salvar()
        {
            pnVM = new ParceiroViewModel();

            //pnVM.CardCode = "C0001";
            //pnVM.Bairro = new NC<string>("Cambuci");
            //pnVM.CardName = new NC<string>("Brian Souza");
            //pnVM.CEP = new NC<string>("01521-000");
            //pnVM.Cidade = new NC<string>("São Paulo");
            //pnVM.Complemento = "AP 42 Bl 3";
            //pnVM.Empresa = new NC<string>("1");
            //pnVM.Endereco = new NC<string>("Cesário Ramalho");
            //pnVM.Estado = new NC<string>("SP");
            //pnVM.Numero = new NC<string>("237");
            //pnVM.Telefone = "(12)99121-0998";

            //pnVM.Salvar.Execute();

            //var cadastrou = pnDados.Object.RetornarParceiro("C0001");
            //Assert.IsNotNull(cadastrou);

            //pnVM
        }
    }
}
