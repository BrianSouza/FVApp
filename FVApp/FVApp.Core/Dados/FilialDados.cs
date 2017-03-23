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
    public class FilialDados : BaseDados, IFilialDados
    {
        public bool DeletarFilial(Filial filial)
        {
            if (dbmService.Delete<Filial>(filial) > 0)
                return true;
            else
                return false;
        }

        public ObservableCollection<Filial> RetornarFiliais()
        {
            return dbmService.GetAll<Filial>();
        }

        public Filial RetornarFilial(string id)
        {
            return dbmService.GetItem<Filial>(id);
        }

        public bool SalvarFilial(Filial filial)
        {
            if (string.IsNullOrEmpty(filial.Key))
            {
                if (dbmService.Insert<Filial>(filial) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<Filial>(filial) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
