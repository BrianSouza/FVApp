using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;

namespace FVApp.Core.Dados.Interface
{
    interface IParceirosDados
    {
        bool SalvarParceiro(Parceiro pn);

        bool DeletarParceiro(Parceiro pn);

        Parceiro RetornarParceiro(string cardCode);

        ObservableCollection<Parceiro> RetornarParceiros();
    }
}
