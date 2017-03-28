using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    public interface IItensDados
    {
        bool SalvarItens(Itens item);

        bool DeletarItens(Itens item);

        Itens RetornarItem(string id);

        ObservableCollection<Itens> RetornarItens();
    }
}
