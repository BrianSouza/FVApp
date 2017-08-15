
using FVApp.Core.Dados.Interface;
using SQLite.Net.Attributes;
using System;

namespace FVApp.Core.Dados.Entidades
{
    public class Pedido : IKeyObject
    {
        [PrimaryKey, AutoIncrement]

        public int Key { get; set; }

        public string DocEntry { get; set; }

        public string CardCode { get; set;}

        public string CardName { get; set; }

        public double ValorTotal { get; set; }

        public string FormarPagamento { get; set; }

        public string CondicaoPagamento { get; set; }

        public DateTime DataCadastro { get; set; } 

        public bool Integrado { get; set; }

    }
}
