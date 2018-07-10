using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.ViewModels;

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
        public ActionResult Index()
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
                     
           
              // ViewBag.Employee = employeeListViewModel;
                //ViewData["Employee"] = emp;
                //return View("MyView");
                return View("Index", employeeListViewModel);
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        /*
        public string SaveEmployee(string FirstName,string LastName,string Salary)
        {
            return FirstName + "|" + LastName + "|" + Salary;
        }
         */
        public ActionResult SaveEmployee(Employee e,string BtnSubmit)
        {
            //MVC 的Model Binder:
            //无论请求是否由带参的action方法生成，Model Binder都会自动执行。
            //Model Binder会通过方法的元参数迭代，然后会和接收到参数名称做对比。如果匹配，则响应接收的数据，并分配给参数。
            //在Model Binder迭代完成之后，将类参数的每个属性名称与接收的数据做对比，如果匹配，则响应接收的数据，并分配给参数。
            //请求信息包含在request对象中,比如：可以通过Request.Form["FirstName"]获取参数FirstName的值
            switch (BtnSubmit)
            {
                case "Save Employee":
                return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                case "Cancel":
                 return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
       
    }
}