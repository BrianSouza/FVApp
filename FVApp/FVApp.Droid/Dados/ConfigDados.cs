using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FVApp.Core.Dados.Interface;
using SQLite.Net.Interop;

namespace FVApp.Droid.Dados
{
    public class ConfigDados : IConfigDados
    {
        private string diretorioDB;
        private ISQLitePlatform plataforma;
        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(diretorioDB))
                {
                    diretorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return diretorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get

            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }

        public ConfigDados()
        {

        }
    }
}