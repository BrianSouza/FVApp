using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVApp.Core.Dados.Interface;
using MvvmCross.Platform;

namespace FVApp.Core.Dados
{
    public class BaseDados
    {
        internal readonly IDataBaseManager dbmService;

        public BaseDados()
        {
            dbmService = Mvx.Resolve<IDataBaseManager>();
        }
    }
}
