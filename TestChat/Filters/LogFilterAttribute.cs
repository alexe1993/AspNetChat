using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestChat.Models;

namespace TestChat.Filters
{
    public class LogFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (ApplicationDbContext database = new ApplicationDbContext())
            {
                var request= filterContext.HttpContext.Request;
                var user = database.Users.FirstOrDefault(item => item.Email == filterContext.HttpContext.User.Identity.Name);
                Visitor visitor = new Visitor()
                {
                    User = user,
                    DateTime = DateTime.UtcNow,
                    Ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                    Url = request.RawUrl,
                    Browser = request.Browser.Browser,
                    UserAgent = request.UserAgent,
                    UserLanguages = String.Join("_", request.UserLanguages)
                };
                database.Visitors.Add(visitor);
                database.SaveChanges();
            }
        }
    }
}