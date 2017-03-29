using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Core.Entidades
{
    public class PedItens
    {
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public double Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        public double ValorTotal { get; set; }
    }
}
