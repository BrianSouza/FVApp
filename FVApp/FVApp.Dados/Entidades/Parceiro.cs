using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Dados.Entidades
{
    public class Parceiro
    {
        public int IdMobile { get; set; }
        
        public string CardCode { get; set; }
        
        public string CardName { get; set; }
        
        public string Endereco { get; set; }
        
        public string Numero { get; set; }
        
        public string Complemento { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }
        
        public string Telefone { get; set; }
    }
}
