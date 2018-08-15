using JQuery.Datatables.Core.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JQuery.Datatables.Core
{
    public abstract class DataTablesAttributeBase : Attribute
    {
        public abstract void ApplyTo(ColDef colDef, PropertyInfo pi);
    }
}
