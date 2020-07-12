namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_pmsTxTimeSheet_Detail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [DisplayName("Time Sheet Code")]
        public string timeSheet_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        [DisplayName("Task Code")]
        public string task_ID { get; set; }

        [DisplayName("Utilized Hours")]
        [Column(Order = 3)]
        public decimal utilizedHours { get; set; }

        [StringLength(20)]
        [DisplayName("Status Code")]
        [DefaultValue("-1")]
        [Column(Order = 4)]
        public string status_ID { get; set; }

        [StringLength(1000)]
        [DisplayName("Remarks")]
        [Column(Order = 5)]
        public string remarks { get; set; }

        public virtual tbl_pmsTxTask tbl_pmsTxTask { get; set; }

        public virtual tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet { get; set; }
    }
}
