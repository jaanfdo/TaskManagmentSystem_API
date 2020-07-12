namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_genMasProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_genMasProduct()
        {
            tbl_pmsTxTask = new HashSet<tbl_pmsTxTask>();
        }

        [Key]
        [StringLength(20)]
        [DisplayName("Product Code")]
        public string product_ID { get; set; }

        [StringLength(200)]
        [DisplayName("Product Name")]
        public string productName { get; set; }

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
        public virtual ICollection<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }

        public virtual ICollection<tbl_genMasModule> tbl_genMasModule { get; set; }
    }
}
