namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class TimeSheet_DetailVM
    {
        public int line_No { get; set; }
     
        public string timeSheet_ID { get; set; }
     
        public string task_ID { get; set; }
        public string task { get; set; }
        public string status_ID { get; set; }
        public string status { get; set; }
        public decimal utilizedHours { get; set; }
        public string remarks { get; set; }
        
    }
}
