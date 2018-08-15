using System.Linq;
using AspnetCore.JQuery.Datatables.Models;
using AspnetCore.JQuery.Web.Domain;
using JQuery.Datatables.AspNetCore;
using JQuery.Datatables.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore.JQuery.Web.Controllers
{
    public class DataTableController : Controller
    {
        public IActionResult Index()
        {
            var getDataUrl = Url.Action(nameof(DataTableController.GetSampleEntities));
            var vm = DataTablesHelper.DataTableVm<SampleEntity>("testTable", getDataUrl);
            vm.Filter = true;

            return View(vm);
        }

        public DataTablesResult<SampleEntity> GetSampleEntities(DataTablesParam dtTableParam)
        {
            var entities = FakeDatabase.Instance.Entities.AsQueryable();
            return DataTablesResult.Create(entities, dtTableParam);
        }
    }
}