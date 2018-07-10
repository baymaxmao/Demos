using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "johnson";
            emp.LastName = "fernandes";
            emp.Salary = 140000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "michael";
            emp.LastName = "jackson";
            emp.Salary = 160000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "robert";
            emp.LastName = "pattinson";
            emp.Salary = 200000;
            employees.Add(emp);

            return employees;
        }
    }
}