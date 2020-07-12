namespace DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_genCompanyBranchMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_genCompanyBranchMaster()
        {
            tbl_genCustomerMaster = new HashSet<tbl_genCustomerMaster>();
            tbl_pmsTxTask = new HashSet<tbl_pmsTxTask>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string company_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string companyBranch_ID { get; set; }

        [StringLength(50)]
        public string branchName { get; set; }        

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string telephone { get; set; }

        [StringLength(50)]
        public string fax { get; set; }

        [StringLength(100)]
        public string hotline { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string website { get; set; }

        [StringLength(50)]
        public string contactPerson { get; set; }

        public virtual tbl_genCompanyInfo tbl_genCompanyInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_genCustomerMaster> tbl_genCustomerMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }
    }
}
