using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ReportViewModels
{
    public class TEstimatedUtilized
    {
        public DateTime TaskStartDate { get; set; }
        public DateTime reported_date { get; set; }
        
        public string task_ID { get; set; }
        public string taskReference { get; set; }
        public string remarks { get; set; }

        public string customer_ID { get; set; }
        public string customerCode { get; set; }

        public string product_ID { get; set; }
        public string productName { get; set; }

        public decimal totalEstimatedHours { get; set; }
        public decimal UtilizedHours { get; set; }
        public decimal TotUtilizedHours { get; set; }
        public decimal EstUtlHours { get; set; }

        public string status_ID { get; set; }
        public string status { get; set; }

        public string assignedUser_ID { get; set; }
        public string assignedUser { get; set; }

    }
}