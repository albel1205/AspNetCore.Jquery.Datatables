﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JQuery.Datatables.Core.Model;

namespace JQuery.Datatables.Core
{
    public class DataTablesRowIdAttribute : DataTablesAttributeBase
    {
        public bool EmitAsColumnName { get; set; }

        public override void ApplyTo(ColDef colDef, PropertyInfo pi)
        {
            // This attribute does not affect rendering
        }

        public DataTablesRowIdAttribute()
        {
            EmitAsColumnName = true;
        }
    }
}
