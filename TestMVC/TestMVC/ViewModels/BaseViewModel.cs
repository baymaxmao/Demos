using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.ViewModels
{
    //封装布局页需要的数据
    public class BaseViewModel
    {
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }
    }
}