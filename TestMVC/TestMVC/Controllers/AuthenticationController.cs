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
                if (bal.IsValidUser(u))
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}