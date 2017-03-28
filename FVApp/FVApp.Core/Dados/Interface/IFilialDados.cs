
using System.Collections.ObjectModel;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    public interface IFilialDados
    {
        bool SalvarFilial(Filial filial);

        bool DeletarFilial(Filial filial);

        Filial RetornarFilial(string id);

        ObservableCollection<Filial> RetornarFiliais();
    }
}
