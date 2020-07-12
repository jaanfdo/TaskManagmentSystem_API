namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_pmsTxTaskEstimation
    {

        public tbl_pmsTxTaskEstimation()
        {
            tbl_pmsTxTaskEstimation_Detail = new HashSet<tbl_pmsTxTaskEstimation_Detail>();
        }

        [Key]
        [StringLength(20)]
        [DisplayName("Estimation Code")]
        public string estimation_ID { get; set; }

        [DisplayName("Estimation Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime estimationDate { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Task ID")]
        public string task_ID { get; set; }

        [DisplayName("Total Estimation")]
        public decimal totalEstimatedHours { get; set; }

        [StringLength(1000)]
        [DisplayName("Remarks")]
        public string remarks { get; set; }

        public bool isApproved { get; set; }

        public bool isCancelled { get; set; }

        [StringLength(20)]
        public string createUser_ID { get; set; }
        

        [StringLength(20)]
        public string modifiedUser_ID { get; set; }

        [StringLength(20)]
        public string deletedUser_ID { get; set; }

        [StringLength(20)]
        public string approvedUser_ID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateCreated { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateModified { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateApproved { get; set; }

        [StringLength(10)]
        public string company_ID { get; set; }

        [StringLength(20)]
        public string companyBranch_ID { get; set; }

        public virtual tbl_pmsTxTask tbl_pmsTxTask { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTaskEstimation_Detail> tbl_pmsTxTaskEstimation_Detail { get; set; }


        public tbl_pmsTxTaskEstimation(string _estimation_ID, DateTime _estimationDate, string _task_ID, decimal _totalEstimatedHours, string _remarks,
            bool _isApproved, bool _isCancelled, string _createUser_ID, string _modifiedUser_ID, string _deletedUser_ID, string _approvedUser_ID,
            DateTime _dateCreated, DateTime _dateModified, DateTime _dateDeleted, DateTime _dateApproved, string _company_ID, string _companyBranch_ID)
        {
            estimation_ID = _estimation_ID;
            estimationDate = _estimationDate;
            task_ID = _task_ID;
            totalEstimatedHours = _totalEstimatedHours;
            remarks = _remarks;
            isApproved = _isApproved;
            isCancelled = _isCancelled;
            createUser_ID = _createUser_ID;
            modifiedUser_ID = _modifiedUser_ID;
            deletedUser_ID = _deletedUser_ID;
            approvedUser_ID = _approvedUser_ID;
            dateCreated = _dateCreated;
            dateModified = _dateModified;
            dateDeleted = _dateDeleted;
            dateApproved = _dateApproved;
            company_ID = _company_ID;
            companyBranch_ID = _companyBranch_ID;
        }

    }
}
