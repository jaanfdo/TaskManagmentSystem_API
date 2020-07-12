namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_pmsTxTimeSheet
    {
        public tbl_pmsTxTimeSheet()
        {
            tbl_pmsTxTimeSheet_Detail = new HashSet<tbl_pmsTxTimeSheet_Detail>();
        }

        [Key]
        [StringLength(20)]
        [DisplayName("Time Sheet Code")]
        public string timeSheet_ID { get; set; }

        [DisplayName("Time Sheet Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime timeSheetDate { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Sub Task")]
        public string subTask_ID { get; set; }

        [StringLength(1000)]
        [DisplayName("Remarks")]
        public string remarks { get; set; }

        [DisplayName("Total Utilized hours")]
        public decimal totalUtilizedHours { get; set; }

        public bool isCancelled { get; set; }

        [StringLength(20)]
        public string user_ID { get; set; }

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

        public virtual tbl_genMasSubTask tbl_genMasSubTask { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTimeSheet_Detail> tbl_pmsTxTimeSheet_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public tbl_pmsTxTimeSheet(string _timeSheet_ID, DateTime _timeSheetDate, string _subTask_ID, decimal _totalUtilizedHours, string _remarks,
           bool _isCancelled, string _user_ID, string _createUser_ID, string _modifiedUser_ID, string _deletedUser_ID,
           DateTime _dateCreated, DateTime _dateModified, DateTime _dateDeleted, string _company_ID, string _companyBranch_ID)
        {
            timeSheet_ID = _timeSheet_ID;
            timeSheetDate = _timeSheetDate;
            subTask_ID = _subTask_ID;
            totalUtilizedHours = _totalUtilizedHours;
            remarks = _remarks;

            isCancelled = _isCancelled;

            user_ID = _user_ID;
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
