using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class CondicaoPagamento : IKeyObject
    {
        public string Key { get; set; }

        public string Descricao { get; set; }

        public int NumeroParcelas { get; set; }

        public string DiasParcelas { get; set; }//separar os dias corridos das parcelas por ";"
    }
}
