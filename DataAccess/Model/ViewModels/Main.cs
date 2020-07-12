using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class Main
    {
        public class UsersVM
        {
            public string user_ID { get; set; }
            public string user { get; set; }
        }

        public class StatusVM
        {
            public string status_ID { get; set; }
            public string status { get; set; }
        }

        public class FunctionVM
        {
            public string function_ID { get; set; }
            public string functionName { get; set; }
        }

        public class ModuleVM
        {
            public string module_ID { get; set; }
            public string moduleName { get; set; }
        }

        public class PriorityVM
        {
            public string priority_ID { get; set; }
            public string priority { get; set; }
        }

        public class ProductVM
        {
            public string product_ID { get; set; }
            public string productName { get; set; }
        }

        public class SubTaskVM
        {
            public string subTask_ID { get; set; }
            public string subTaskName { get; set; }
        }

        public class TaskTypeVM
        {
            public string taskType_ID { get; set; }
            public string taskType { get; set; }
        }


    }
}