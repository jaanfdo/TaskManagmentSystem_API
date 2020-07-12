namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_genMasSubTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_genMasSubTask()
        {
            tbl_pmsTxTaskEstimation_Detail = new HashSet<tbl_pmsTxTaskEstimation_Detail>();
            tbl_pmsTxTimeSheet = new HashSet<tbl_pmsTxTimeSheet>();
        }

        [Key]
        [StringLength(20)]
        [DisplayName("Sub Task Code")]
        public string subTask_ID { get; set; }

        [StringLength(200)]
        [DisplayName("Sub Task Name")]
        public string subTaskName { get; set; }

        public bool? isMandatoryRemarks { get; set; }

        public bool? isActive { get; set; }

        [StringLength(20)]
        public string createUser_ID { get; set; }

        [StringLength(20)]
        public string modifiedUser_ID { get; set; }

        [StringLength(20)]
        public string deletedUser_ID { get; set; }

        public DateTime? dateCreated { get; set; }

        public DateTime? dateModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTaskEstimation_Detail> tbl_pmsTxTaskEstimation_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTimeSheet> tbl_pmsTxTimeSheet { get; set; }
    }
}
