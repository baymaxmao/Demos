﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Filters;
using TestMVC.ViewModels;
using TestMVC.Models;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace TestMVC.Controllers
{
    
   // [HandleError]
    public class BulkUploadController:AsyncController
    {
       [AdminFilter]
       [HeaderFooterFilter]
       public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }
        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            int t1 = Thread.CurrentThread.ManagedThreadId;
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(()=>GetEmployees(model));
            int t2 = Thread.CurrentThread.ManagedThreadId;
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index","Employee");
        }
      
        public List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine();
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary =int.Parse(values[2]);
                employees.Add(e);
            }
            return employees;
        }
    }
}