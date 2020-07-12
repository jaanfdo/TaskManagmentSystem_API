namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_securityUserPermission
    {
        [Key]
        [StringLength(20)]
        [DisplayName("Permission Code")]
        public string permission_ID { get; set; }

        [StringLength(200)]
        [DisplayName("Permission Name")]
        public string permissionName { get; set; }

        public bool? isReport_Permission { get; set; }

        public virtual ICollection<tbl_securityGroupPermission> tbl_securityGroupPermission { get; set; }
    }
}
