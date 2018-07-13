using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC.DataAccessLayer;

namespace TestMVC.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.employees.ToList();
            /*
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
            */

        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        /*
        public bool IsValidUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
                return false;
        }
        */
        public UserStatus GetUserValidity(UserDetails u)
        {
            if(u.UserName=="Admin" && u.Password=="Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if(u.UserName=="Sukesh" && u.Password=="Sukesh")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.employees.AddRange(employees);
            salesDal.SaveChanges();
        }
       
    }
}