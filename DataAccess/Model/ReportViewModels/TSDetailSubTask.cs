using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ReportViewModels
{
    public class TSDetailSubTask
    {
        public string timeSheet_ID { get; set; }
        public DateTime timeSheetDate { get; set; }

        public string task_ID { get; set; }
        public string taskReference { get; set; }
        public string remarks { get; set; }

        public string subTask_ID { get; set; }
        public string subTaskName { get; set; }
        public decimal utilizedHours { get; set; }

        public string user_ID { get; set; }
        public string userName { get; set; }

        public string status_ID { get; set; }
        public string status { get; set; }

        public string customer_ID { get; set; }
        public string customerCode { get; set; }
    }
}