using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.ViewModels;
using TestMVC.Filters;

namespace TestMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        /*
        public string Index()
        {
            return "hello,world!";
        }
        */
        //通过连接地址中可以传入参数
        [Authorize]
        [HeaderFooterFilter]
        //加了认证属性会先通过web.config设置的authertication跳转到登录页面
        //仅仅放在这里授权是有问题的,还是可以通过链接http://localhost:55031/Employee/AddNew访问页面
        [Route("Employee/List/{id}")]
        public ActionResult Index(string id)
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (Employee emp in employees)
            {

                EmployeeViewModel vmEmp = new EmployeeViewModel();
                vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
                vmEmp.Salary = emp.Salary.ToString();
                vmEmp.SalaryColor = emp.Salary > 150000 ? "yellow" : "green";
                employeeViewModels.Add(vmEmp);
            }
            employeeListViewModel.Employees = employeeViewModels;

            Console.WriteLine("输入参数id:的值" );
              // ViewBag.Employee = employeeListViewModel;
                //ViewData["Employee"] = emp;
                //return View("MyView");
                return View("Index", employeeListViewModel);
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            return View("CreateEmployee",new CreateEmployeeViewModel());
        }
        /*
        public string SaveEmployee(string FirstName,string LastName,string Salary)
        {
            return FirstName + "|" + LastName + "|" + Salary;
        }
         */
         //授权认证
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e,string BtnSubmit)
        {
            //处理参数名称与类属性不匹配的情况，使用Request类获取参数的值再赋值给类实例
            /*
             e.FirstName = Request.Form["FirstName"];

             e.LastName = Request.Form["LastName"];

                 e.Salary = Convert.ToInt32(Request.Form["Salary"]);
           */
            //MVC 的Model Binder:
            //无论请求是否由带参的action方法生成，Model Binder都会自动执行。
            //Model Binder会通过方法的元参数迭代，然后会和接收到参数名称做对比。如果匹配，则响应接收的数据，并分配给参数。
            //在Model Binder迭代完成之后，将类参数的每个属性名称与接收的数据做对比，如果匹配，则响应接收的数据，并分配给参数。
            //请求信息包含在request对象中,比如：可以通过Request.Form["FirstName"]获取参数FirstName的值
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        vm.Salary = e.Salary.HasValue ? e.Salary.ToString() : ModelState["Salary"].Value.AttemptedValue;
                        return View("CreateEmployee", vm);
                    }
                case "Cancel":
                return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
        public ActionResult GetAddNewLink()
        {
            if(Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
       
    }
}