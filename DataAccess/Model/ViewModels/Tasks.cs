using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class Tasks
    {
        public string task_ID { get; set; }
        public DateTime taskDate { get; set; }
        public string taskReference { get; set; }
        public string remarks { get; set; }
        public DateTime reportedDate { get; set; }
        public string reportedUser_ID { get; set; }
        public string customer_ID { get; set; }
        public string product_ID { get; set; }
        public string module_ID { get; set; }
        public string function_ID { get; set; }
        public string taskType_ID { get; set; }
        public string priority_ID { get; set; }
        public string status_ID { get; set; }
    }
}