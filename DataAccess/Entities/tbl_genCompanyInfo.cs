namespace DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_genCompanyInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_genCompanyInfo()
        {
            tbl_genCustomerMaster = new HashSet<tbl_genCustomerMaster>();
            tbl_pmsTxTask = new HashSet<tbl_pmsTxTask>();
        }

        [Key]
        [StringLength(10)]
        public string company_ID { get; set; }

        [StringLength(200)]
        public string companyName { get; set; }

        [StringLength(1000)]
        public string address { get; set; }

        [StringLength(25)]
        public string telephone1 { get; set; }

        [StringLength(25)]
        public string telephone2 { get; set; }

        [StringLength(25)]
        public string telephone3 { get; set; }

        [StringLength(25)]
        public string fax { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        [StringLength(20)]
        public string vatRegisterNo { get; set; }

        [StringLength(20)]
        public string businessRegisterNo { get; set; }

        [StringLength(20)]
        public string financialYear_ID { get; set; }

        [StringLength(200)]
        public string productKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_genCustomerMaster> tbl_genCustomerMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }

        public virtual ICollection<tbl_genCompanyBranchMaster> tbl_genCompanyBranchMaster { get; set; }
    }
}
