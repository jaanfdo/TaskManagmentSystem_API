using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class TaskBucketVM
    {
        public string task_ID { get; set; }
        public DateTime? taskDate { get; set; }
        public string taskReference { get; set; }
        public string taskType_ID { get; set; }
        public string remarks { get; set; }

        public string estimation_ID { get; set; }

        public string priority_ID { get; set; }
        public string status_ID { get; set; }
        public string status { get; set; }

        public DateTime? DeadlineDate { get; set; }
        public int DeadlineCounter { get; set; }
        public string AssignedTo { get; set; }

        public string client_ID { get; set; }
        public string product_ID { get; set; }
        public string module_ID { get; set; }
        public string function_ID { get; set; }

        public DateTime? reported_Date { get; set; }
        public string reportedUser_ID { get; set; }

        public bool? isApproved { get; set; }
        public bool? isCancelled { get; set; }

    }

    public class TaskDeadLineVM
    {
        public string task_ID { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string AssignedTo { get; set; }
    }
}