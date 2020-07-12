using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class TaskVM
    {
        public string task_ID { get; set; }        
        public string taskDate { get; set; }        
        public string taskReference { get; set; }        
        public string remarks { get; set; }        
        public string reported_Date { get; set; }        
        public string reportedUser_ID { get; set; }
        
        public string customer_ID { get; set; }        
        public string product_ID { get; set; }        
        public string module_ID { get; set; }        
        public string function_ID { get; set; }        
        public string taskType_ID { get; set; }
        public string priority_ID { get; set; }        
        public string status_ID { get; set; }
        public string DeadlineDate { get; set; }        
        public string assignedUser { get; set; }        
        public string isAttachment { get; set; }

        public string customer { get; set; }
        public string product { get; set; }
        public string module { get; set; }
        public string function { get; set; }
        public string taskType { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
    }
}