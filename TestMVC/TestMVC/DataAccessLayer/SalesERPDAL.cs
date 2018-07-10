using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestMVC.Models;

namespace TestMVC.DataAccessLayer
{
    public class SalesERPDAL:DbContext
    {
        
        //DbSet表示数据库中能够被查询的所有Employee
        //DbSet数据集是数据库方面的概念 ，指数据库中可以查询的实体的集合。
        //当执行Linq 查询时，Dbset对象能够将查询内部转换，并触发数据库。
        //当每次需要访问employees时，会获取“TblEmployee”的所有记录，并转换为Employee对象，返回Employee对象集
        //数据访问层和数据库之间的映射通过名称实现的,ConnectionString（连接字符串）的名称和数据访问层的类名称是相同的，都是SalesERPDAL，因此会自动实现映射。
        //可以更改连接字符串的名称，更改类的构造函数即可
        /*
         public SalesERPDAL() : base("NewName")
        {

        }
        */
        public DbSet<Employee> employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //“TblEmployee”是表名称，是运行时自动生成的
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
}