using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TestMVC.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("E://Error//" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt",
                new string[]
                {
                    "Message:"+e.Message,
                    "Stacktrace"+e.StackTrace
                });
        }
    }
}