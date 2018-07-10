using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Employee
    {
        //为什么EmployeeId主键自增?
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName
        {
            get;set;
        }
        public string LastName
        {
            get;set;
        }
        public int Salary
        {
            get;set;
        }
    }
}