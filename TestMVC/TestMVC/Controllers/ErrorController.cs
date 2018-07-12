using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMVC.Controllers
{
    [AllowAnonymous]
    //将AllowAnonymous属性应用到 ErrorController中，因为错误控制器和index方法不应该只绑定到认证用户，
    //也很有可能用户在登录之前已经输入错误的URL
    public class ErrorController:Controller
    {
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or/and Action");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}