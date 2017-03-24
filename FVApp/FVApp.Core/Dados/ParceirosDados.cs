using System;
using System.Collections.ObjectModel;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;

namespace FVApp.Core.Dados
{
    public class ParceirosDados : BaseDados, IParceirosDados
    {
        public bool DeletarParceiro(Parceiro pn)
        {
            if (dbmService.Delete<Parceiro>(pn) > 0)
                return true;
            else
                return false;
        }

        public Parceiro RetornarParceiro(string cardCode)
        {
            return dbmService.GetItem<Parceiro>(cardCode);
        }

        public ObservableCollection<Parceiro> RetornarParceiros()
        {
            return dbmService.GetAll<Parceiro>();


        }

        public bool SalvarParceiro(Parceiro pn)
        {
            if(string.IsNullOrEmpty(pn.Key))
            {
                if (dbmService.Insert<Parceiro>(pn) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (dbmService.Update<Parceiro>(pn) > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
