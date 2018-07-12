using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class AuthenticationController: Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //DoLogin添加HttpPost属性，该属性可使得DoLogin 方法打开Post 请求。如果有人尝试获取DoLogin()，直接在链接地址中输入DoLogin,将不会起作用。还有很多类似的属性如HttpGet，HttpPut和HttpDelete属性.
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
                UserStatus status = bal.GetUserValidity(u);
                bool IsAdmin = false;
                if (status == UserStatus.AuthenticatedAdmin)
                {
                    IsAdmin = true;
                }
                else if(status==UserStatus.AuthentucatedUser)
                {
                    IsAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                //Session是Asp.Net的特性之一，可以在MVC中重用，可用于暂存用户相关数据，session变量周期是穿插于整个用户生命周期的
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Employee");            
        }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //必须增加清除Session的代码，否则logout后还是能访问AddNew
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}