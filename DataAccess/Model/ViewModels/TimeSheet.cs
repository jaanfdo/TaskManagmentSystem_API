using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class TimeSheet
    {
        public string timeSheet_ID { get; set; }

        public DateTime timeSheetDate { get; set; }

        public string subTask_ID { get; set; }

        public string remarks { get; set; }

        public decimal totalUtilizedHours { get; set; }

        public List<TimeSheet_DetailVM> TimeSheetDetails { get; set; }
    }
}