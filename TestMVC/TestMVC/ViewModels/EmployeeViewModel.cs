using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.ViewModels
{
    public class EmployeeViewModel
    {
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryColor { get; set; }
      
    }
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        
    }
}