﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Employee
    {
        //为什么EmployeeId主键自增--由DataAnnotations决定的
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName
        {
            get;set;
        }
        [StringLength(5,ErrorMessage ="Last Name length should not be greater than 5")]
        public string LastName
        {
            get;set;
        }
       
        public int? Salary
        {
            get;set;
        }
    }
}