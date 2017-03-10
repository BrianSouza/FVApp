
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class Itens : IKeyObject
    {
        public string Key { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public double PrecoUnit { get; set; }

        public string Empresa { get; set; }

    }
}
