﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JQuery.Datatables.Core.Model
{
    public class Language
    {
        public string sProcessing { get; set; }
        public string sLengthMenu { get; set; }
        public string sZeroRecords { get; set; }
        public string sInfo { get; set; }
        public string sInfoEmpty { get; set; }
        public string sInfoFiltered { get; set; }
        public string sInfoPostFix { get; set; }
        public string sSearch { get; set; }
        public string sUrl { get; set; }
        public Paginate oPaginate { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
