namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_pmsTxTaskEstimation_Detail
    {
        //public tbl_pmsTxTaskEstimation_Detail(int _line_No, string _estimation_ID, string _subTask_ID, decimal _estimatedHours)
        //{
        //    line_No = _line_No;
        //    estimation_ID = _estimation_ID;
        //    subTask_ID = _subTask_ID;
        //    estimatedHours = _estimatedHours;
        //}

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [DisplayName("Estimation Code")]
        public string estimation_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        [DisplayName("Sub Task")]
        public string subTask_ID { get; set; }

        [DisplayName("Estimated Hours")]
        public decimal estimatedHours { get; set; }

        public virtual tbl_genMasSubTask tbl_genMasSubTask { get; set; }

        public virtual tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation { get; set; }
    }
}
