namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class TimeSheetVM
    {
        public string user_ID { get; set; }
        public string user { get; set; }
        public string timeSheet_ID { get; set; }
        
        public DateTime? timeSheetDate { get; set; }
        
        public string subTask_ID { get; set; }
        public string subTask { get; set; }

        public string remarks { get; set; }
        
        public decimal? totalUtilizedHours { get; set; }

        public bool? isCancelled { get; set; }

    }
}
