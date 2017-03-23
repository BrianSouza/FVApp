using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    interface IFormasPagamentoDados
    {
        bool SalvarFormaPagamento(FormaPagamento pn);

        bool DeletarFormaPagamento(FormaPagamento pn);

        FormaPagamento RetornarFormaPagamento(string forma);

        ObservableCollection<FormaPagamento> RetornarFormasPagamento();
    }
}
