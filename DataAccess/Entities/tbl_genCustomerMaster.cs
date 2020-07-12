namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_genCustomerMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_genCustomerMaster()
        {
            tbl_pmsTxTask = new HashSet<tbl_pmsTxTask>();
        }

        [Key]
        [StringLength(20)]
        public string customer_ID { get; set; }

        [StringLength(50)]
        public string customerCode { get; set; }

        [StringLength(250)]
        public string customerName { get; set; }

        [StringLength(500)]
        public string addressRegister { get; set; }

        [StringLength(500)]
        public string addressDelivery { get; set; }

        [StringLength(50)]
        public string telephone { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string fax { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        [StringLength(50)]
        public string businessRegistraionNo { get; set; }

        [StringLength(50)]
        public string vatRegistrationNo { get; set; }

        [StringLength(50)]
        public string nbtRegistrationNo { get; set; }

        [StringLength(50)]
        public string svatRegistrationNo { get; set; }

        [StringLength(100)]
        public string remark { get; set; }

        public bool? isBlacklisted { get; set; }

        public bool? isLocked { get; set; }

        public bool? isDeleted { get; set; }

        [StringLength(10)]
        public string country_ID { get; set; }

        [StringLength(10)]
        public string province_ID { get; set; }

        [StringLength(10)]
        public string district_ID { get; set; }

        [StringLength(10)]
        public string city_ID { get; set; }

        [StringLength(10)]
        public string town_ID { get; set; }

        [StringLength(10)]
        public string area_ID { get; set; }

        [StringLength(20)]
        public string route_ID { get; set; }

        [StringLength(10)]
        public string customerType_ID { get; set; }

        [StringLength(10)]
        public string customerCategory_ID { get; set; }

        [StringLength(10)]
        public string customerClass_ID { get; set; }

        [StringLength(10)]
        public string currency_ID { get; set; }

        [StringLength(20)]
        public string salesManager_ID { get; set; }

        [StringLength(20)]
        public string areaManager_ID { get; set; }

        [StringLength(20)]
        public string salesRep_ID { get; set; }

        [StringLength(20)]
        public string salesExecutive_ID { get; set; }

        [StringLength(20)]
        public string gl_ID { get; set; }

        public bool? isVATenable { get; set; }

        public bool? isSVATenable { get; set; }

        public bool? isNBTenable { get; set; }

        public bool? isCustomerPricingEnable { get; set; }

        public bool? isCustomerWiseItemCode { get; set; }

        [StringLength(20)]
        public string title { get; set; }

        [StringLength(20)]
        public string nicNo { get; set; }

        public DateTime? dateOfBirth { get; set; }

        [StringLength(20)]
        public string customerAccountType_ID { get; set; }

        public bool? isPostingEnable_VAT { get; set; }

        public bool? isPostingEnable_NBT { get; set; }

        [StringLength(20)]
        public string salesReturnedGL_ID { get; set; }

        public bool? isCashCustomer { get; set; }

        [StringLength(10)]
        public string company_ID { get; set; }

        [StringLength(20)]
        public string companyBranch_ID { get; set; }

        public int? itemPriceMode { get; set; }

        [StringLength(20)]
        public string itemPriceCategory { get; set; }

        [StringLength(20)]
        public string createUser_ID { get; set; }

        [StringLength(20)]
        public string modifiedUser_ID { get; set; }

        [StringLength(20)]
        public string deletedUser_ID { get; set; }

        [StringLength(50)]
        public string createTerminal_ID { get; set; }

        [StringLength(50)]
        public string modifiedTerminal_ID { get; set; }

        [StringLength(50)]
        public string deletedTerminal_ID { get; set; }

        public DateTime? dateCreate { get; set; }

        public DateTime? dateModified { get; set; }

        public DateTime? dateDeleted { get; set; }

        [StringLength(20)]
        public string sales_Gl_ID { get; set; }

        public bool? isPOSCustomer { get; set; }

        public virtual tbl_genCompanyBranchMaster tbl_genCompanyBranchMaster { get; set; }

        public virtual tbl_genCompanyInfo tbl_genCompanyInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }
    }
}
