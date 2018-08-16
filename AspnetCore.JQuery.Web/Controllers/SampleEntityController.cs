using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCore.JQuery.Datatables.Models;
using AspnetCore.JQuery.Web.Domain;
using JQuery.Datatables.AspNetCore;
using JQuery.Datatables.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore.JQuery.Web.Controllers
{
    public class SampleEntityController : DataTableController<SampleEntity>
    {
        protected override IQueryable<SampleEntity> DoQueryTableData()
        {
            return FakeDatabase.Instance.Entities.AsQueryable();
        }

        protected override object TransformColumns(SampleEntity model)
        {
            return new
            {
                Id = string.Format("<a href='{0}'>Edit</a>", model.Id),
                IsDirty = string.Format("<input type='checkbox' {0}/>", model.IsDirty ? "checked" : "")
            };
        }
    }
}