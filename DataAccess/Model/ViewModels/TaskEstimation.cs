using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class TaskEstimation
    {
        public string estimation_ID { get; set; }
        public DateTime estimationDate { get; set; }
        public string task_ID { get; set; }
        public decimal totalEstimatedHours { get; set; }
        public string remarks { get; set; }
        public List<tbl_pmsTxTaskEstimation_Detail> TaskEstimationDetails { get; set; }
    }
}