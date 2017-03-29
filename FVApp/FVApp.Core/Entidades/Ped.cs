using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Entidades;

namespace FVApp.Core.Entidades
{
    public class Ped
    {
        public string Key { get; set; }

        public string CardCode { get; set; }

        public string CardName { get; set; }

        public double ValorTotal { get; set; }

        public FormPgto FP { get; set; }

        public CondPagto CP { get; set; }

        public PedItens PItens { get; set; }
    }
}
