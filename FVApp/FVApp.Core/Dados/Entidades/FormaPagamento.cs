using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class FormaPagamento : IKeyObject
    {
        public string Key { get; set; }

        public string Descricao { get; set; }

        public string Empresa { get; set; }
    }
}
