using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //通过属性来设置路由地址
            routes.MapMvcAttributeRoutes();
            //地址既可以通过/Employee/BulkUpload访问-第一种注册路由的方式但是会先试着匹配Default
            //Employee匹配Controller,BulkUpload匹配action
            //也可以通过/BulkUpload/Upload访问-第二种注册路由的方式

            routes.MapRoute(
               name: "Upload",
               url: "Employee/BulkUpload",
               defaults: new { controller = "BulkUpload", action = "Index"}
           );

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            /*
            routes.MapRoute(
                "MyRoute",
                "Employee/{EmpId}",
                new {controller="Employee",action="GetEmployeeById"},
                new {EmpId=@"\d+"}
                );
                */
        }
    }
}
