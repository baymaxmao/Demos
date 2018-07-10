using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.ViewModels;

namespace TestMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "hello,world!";
        }
        //通过连接地址中可以传入参数
        public ActionResult GetView(int id)
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
            employeeListViewModel.UserName = "Admin";
           
            
            if (id == 0)
            {
              // ViewBag.Employee = employeeListViewModel;
                //ViewData["Employee"] = emp;
                //return View("MyView");
                return View("MyView", employeeListViewModel);
            }
            else
                return View("NotMyView");
        }
    }
}