using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Common;
using HomeCare.Application.Common.Helper;
using HomeCare.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace HomeCare.Areas.Helper.Controllers
{
    [Area("Helper")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = HttpContext.Session.Get<HelperLogin>(CommonConstants.HELPER_SESSION);
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Helper" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}