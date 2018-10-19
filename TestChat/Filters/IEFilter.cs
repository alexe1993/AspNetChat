using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestChat.Filters
{
    public class IEFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Browser.Browser.Contains("Explorer"))
            {
                filterContext.Result = new RedirectResult("~/Errors/IeError");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}