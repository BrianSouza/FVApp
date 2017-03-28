
using System.Collections.ObjectModel;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    public interface ICondicoesPagamentoDados
    {
        bool SalvarCondicao(CondicaoPagamento pn);

        bool DeletarCondicao(CondicaoPagamento pn);

        CondicaoPagamento RetornarCondicao(string cardCode);

        ObservableCollection<CondicaoPagamento> RetornarCondicoes();
    }
}
