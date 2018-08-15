using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JQuery.Datatables.AspNetCore
{
    class Settings
    {
        public IFileProvider FileProvider { get; set; }
    }
}
