using System.Collections.Generic;
using System.Linq;
using AspnetCore.JQuery.Datatables.Models;
using AspnetCore.JQuery.Web.Domain;
using JQuery.Datatables.AspNetCore;
using JQuery.Datatables.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore.JQuery.Web.Controllers
{
    public abstract class DataTableController<T> : Controller 
        where T : class
    {
        public virtual IActionResult Index()
        {
            var vm = ConfigureDataTable();
            return View(vm);
        }

        protected virtual DataTableConfigVm ConfigureDataTable()
        {
            var getDataUrl = Url.Action(nameof(this.GetTableData));
            var vm = DataTablesHelper.DataTableVm<T>(BuildTableID(), getDataUrl);

            vm.Filter = true;
            vm.ShowFilterInput = true;

            vm.TableTools = false;

            vm.PageLength = 10;

            vm.ColVis = false;

            return vm;
        }

        protected virtual string BuildTableID()
        {
            return nameof(this.Index);
        }

        public virtual DataTablesResult<T> GetTableData(DataTablesParam dtTableParam)
        {
            var data = DoQueryTableData();
            return DataTablesResult.Create(data, dtTableParam, this.TransformColumns);
        }

        protected virtual object TransformColumns(T model)
        {
            return model;
        }

        protected abstract IQueryable<T> DoQueryTableData();
    }
}