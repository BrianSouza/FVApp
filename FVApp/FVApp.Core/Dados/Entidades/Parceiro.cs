
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados.Entidades
{
    public class Parceiro : IKeyObject
    {
        public string Key { get; set; }

        public string CardCode { get; set; }

        public string CardName { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string CEP { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }

        public string Empresa { get; set; }

        public string Documento { get; set; }
        public string TipoDocumento { get; set; }

        public string TipoParceiro { get; set; }

    }
}
