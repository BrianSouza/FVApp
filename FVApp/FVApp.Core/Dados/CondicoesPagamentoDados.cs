
using System.Collections.ObjectModel;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados
{
    public class CondicoesPagamentoDados : BaseDados,ICondicoesPagamentoDados
    {
        public bool DeletarCondicao(CondicaoPagamento cp)
        {
            if (dbmService.Delete<CondicaoPagamento>(cp) > 0)
                return true;
            else
                return false;
        }

        public CondicaoPagamento RetornarCondicao(string cp)
        {
            return dbmService.GetItem<CondicaoPagamento>(cp);
        }

        public ObservableCollection<CondicaoPagamento> RetornarCondicoes()
        {
            return dbmService.GetAll<CondicaoPagamento>();
        }

        public bool SalvarCondicao(CondicaoPagamento cp)
        {
            if (string.IsNullOrEmpty(cp.Key))
            {
                if (dbmService.Insert<CondicaoPagamento>(cp) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<CondicaoPagamento>(cp) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
