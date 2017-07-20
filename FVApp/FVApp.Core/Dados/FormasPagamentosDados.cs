
using System.Collections.ObjectModel;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados
{
    public class FormasPagamentosDados : BaseDados, IFormasPagamentoDados
    {
        public bool DeletarFormaPagamento(FormaPagamento fp)
        {
            if (dbmService.Delete<FormaPagamento>(fp) > 0)
                return true;
            else
                return false;
        }

        public FormaPagamento RetornarFormaPagamento(string forma)
        {
            return dbmService.GetItem<FormaPagamento>(forma);
        }

        public ObservableCollection<FormaPagamento> RetornarFormasPagamento()
        {
            return dbmService.GetAll<FormaPagamento>();
        }

        public bool SalvarFormaPagamento(FormaPagamento fp)
        {
            if (fp.Key > 0)
            {
                if (dbmService.Insert<FormaPagamento>(fp) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<FormaPagamento>(fp) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
