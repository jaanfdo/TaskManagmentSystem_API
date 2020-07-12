namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class TaskEstimation_DetailVM
    {
        public int line_No { get; set; }
        public string estimation_ID { get; set; }
        public string subTask_ID { get; set; }
        public string subTask { get; set; }
        public decimal? estimatedHours { get; set; }
    }
}
