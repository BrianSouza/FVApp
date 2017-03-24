using MvvmCross.Test.Core;
using Moq;
using NUnit.Framework;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Testes
{
    [TestFixture]
    public class ParceiroViewModelTest : MvxIoCSupportingTest
    {
        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            //var crudParceiro = new Mock<IParceirosDados>();
            //Ioc.RegisterSingleton<IParceirosDados>(crudParceiro.Object);
        }

        [Test]
        public void Valida_se_propriedades_estao_preenchidas()
        {
            base.Setup();

        }
    }
}