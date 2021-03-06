﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVApp.Core.Services
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);

        void ExcludeFile(string filename);

        bool ValidateExist(string fileName);
    }
}
