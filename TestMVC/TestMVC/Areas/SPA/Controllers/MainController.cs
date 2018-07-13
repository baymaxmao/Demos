using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OldViewModel = TestMVC.ViewModels;
using System.Web.Mvc;
using TestMVC.ViewModels.SPA;
using TestMVC.Models;

namespace TestMVC.Areas.SPA.Controllers
{
    public class MainController:Controller
    {
        public ActionResult Index()
        {
            MainViewModel v = new MainViewModel();
           
            v.UserName = User.Identity.Name;
            v.FooterData = new OldViewModel.FooterViewModel();
            v.FooterData.CompanyName = "武汉网友科技";
            v.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", v);
        }
        public ActionResult EmployeeList()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
            foreach(Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.Value.ToString();
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.employees = empViewModels;
            return View("EmployeeList", employeeListViewModel);
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