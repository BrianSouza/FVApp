using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Interface;
using SQLite.Net.Attributes;

namespace FVApp.Core.Dados.Entidades
{
    public class FormaPagamento : IKeyObject
    {
        [PrimaryKey, AutoIncrement]

        public int Key { get; set; }

        public string Code { get; set; }
        public string Descricao { get; set; }

        public string Empresa { get; set; }
    }
}
