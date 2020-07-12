namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_pmsTxTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_pmsTxTask()
        {
            tbl_pmsTxTaskEstimation = new HashSet<tbl_pmsTxTaskEstimation>();
            tbl_pmsTxTimeSheet_Detail = new HashSet<tbl_pmsTxTimeSheet_Detail>();
        }

        [Key]
        [StringLength(20)]
        [DisplayName("Task Code")]
        public string task_ID { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? taskDate { get; set; }

        [StringLength(1000)]
        [DisplayName("Task Reference")]
        public string taskReference { get; set; }

        [StringLength(1000)]
        [DisplayName("Remarks")]
        public string remarks { get; set; }

        [DisplayName("Reported Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? reported_Date { get; set; }

        [StringLength(20)]
        [DisplayName("Reported User")]
        [Required]
        public string reportedUser_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Client")]
        [Required]
        public string customer_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Product")]
        [Required]
        public string product_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Module")]
        [Required]
        public string module_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Function")]
        public string function_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Task Type")]
        [Required]
        public string taskType_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Priority")]
        [Required]
        public string priority_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Status")]
        [Required]
        public string status_ID { get; set; }

        [DisplayName("Deadline")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeadlineDate { get; set; }

        [StringLength(20)]
        public string assignedUser_ID { get; set; }

        [DefaultValue(false)]
        public bool isAttachment { get; set; }

        [DefaultValue(false)]
        public bool isCancelled { get; set; }

        [StringLength(20)]
        public string createUser_ID { get; set; }

        [StringLength(20)]
        public string modifiedUser_ID { get; set; }

        [StringLength(20)]
        public string deletedUser_ID { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime dateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateModified { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateDeleted { get; set; }

        [StringLength(10)]
        public string company_ID { get; set; }

        [StringLength(20)]
        public string companyBranch_ID { get; set; }

        public virtual tbl_genCompanyBranchMaster tbl_genCompanyBranchMaster { get; set; }

        public virtual tbl_genCompanyInfo tbl_genCompanyInfo { get; set; }

        public virtual tbl_genCustomerMaster tbl_genCustomerMaster { get; set; }

        public virtual tbl_genMasFunction tbl_genMasFunction { get; set; }

        public virtual tbl_genMasModule tbl_genMasModule { get; set; }

        public virtual tbl_genMasPriority tbl_genMasPriority { get; set; }

        public virtual tbl_genMasProduct tbl_genMasProduct { get; set; }

        public virtual tbl_genMasStatus tbl_genMasStatus { get; set; }

        public virtual tbl_genMasTaskType tbl_genMasTaskType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTaskEstimation> tbl_pmsTxTaskEstimation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTimeSheet_Detail> tbl_pmsTxTimeSheet_Detail { get; set; }

        public tbl_pmsTxTask(string _taskID, DateTime _taskDate, string _taskReference, string _remarks, DateTime _reported_Date, string _reportedUser_ID, 
             string _customer_ID, string _product_ID, string _module_ID, string _function_ID,  string _taskType_ID, string _priority_ID, string _status_ID, 
             DateTime _DeadlineDate, string _assignedUser_ID, bool _isAttachment, string _createUser_ID, string _modifiedUser_ID, string _deletedUser_ID,
             DateTime _dateCreated, DateTime _dateModified, DateTime _dateDeleted, string _company_ID, string _companyBranch_ID)
        {
            task_ID = _taskID;
            taskDate = _taskDate;
            taskReference = _taskReference;
            remarks = _remarks;
            reported_Date = _reported_Date;
            reportedUser_ID = _reportedUser_ID;

            customer_ID = _customer_ID;
            product_ID = _product_ID;
            module_ID = _module_ID;
            function_ID = _function_ID;
            taskType_ID = _taskType_ID;
            priority_ID = _priority_ID;
            status_ID = _status_ID;

            DeadlineDate = _DeadlineDate;
            assignedUser_ID = _assignedUser_ID;
            isAttachment = _isAttachment;
            createUser_ID = _createUser_ID;
            modifiedUser_ID = _modifiedUser_ID;
            deletedUser_ID = _deletedUser_ID;
            dateCreated = _dateCreated;
            dateModified = _dateModified;
            dateDeleted = _dateDeleted;

            company_ID = _company_ID;
            companyBranch_ID = _companyBranch_ID;
        }
    }
}
