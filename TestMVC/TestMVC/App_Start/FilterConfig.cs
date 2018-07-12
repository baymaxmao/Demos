using System;
using System.Web;
using System.Web.Mvc;
using TestMVC.Filters;

namespace TestMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            /*
            filters.Add(new HandleErrorAttribute()
            {
            // View="MyError"
            });
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType=typeof(FormatException),
                View="~/Views/Error/MyError.cshtml"
                
            });
            */
            filters.Add(new EmployeeExceptionFilter());
            // filters.Add(new AuthorizeAttribute());

        }
    }
}
