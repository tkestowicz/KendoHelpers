using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoHelpers;
using KendoHelpersSampleApp.Models;
using KendoHelpersSampleApp.QueryObjects;

namespace KendoHelpersSampleApp.Controllers
{
    public class PeopleDataController : Controller
    {
        readonly DataContext dataContext = new DataContext();

        public ActionResult ReadPeople([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dataContext.FindAllPeople().ToDataSourceResult(
                request.SortAttributesMapping(PeopleExtensions.SortMappings)
                        .GroupAttributesMapping(PeopleExtensions.GroupMappings)
                        .FilterAttributesMapping(PeopleExtensions.FilterMappings))
                );
        }
	}
}