using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados
{
    public class ItensDados : BaseDados, IItensDados
    {
        public bool DeletarItens(Itens item)
        {
            if (dbmService.Delete<Itens>(item) > 0)
                return true;
            else
                return false;
        }

        public Itens RetornarItem(string id)
        {
            return dbmService.GetItem<Itens>(id);
        }

        public ObservableCollection<Itens> RetornarItens()
        {
            return dbmService.GetAll<Itens>();
        }

        public bool SalvarItens(Itens item)
        {
            if (item.Key>0)
            {
                if (dbmService.Insert<Itens>(item) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<Itens>(item) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
