
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class Filial : IKeyObject
    {
        public string Key { get; set; }

        public string RazaoSocial { get; set; }

        public string Empresa { get; set; }
    }
}
