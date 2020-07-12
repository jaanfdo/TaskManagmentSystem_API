namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_securityGroupPermission
    {
        [Key]
        [StringLength(20)]
        [DisplayName("Group Code")]
        public string group_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Permission Code")]
        public string permission_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Company Code")]
        public string company_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Branch Code")]
        public string branch_ID { get; set; }


        public virtual tbl_securityGroup tbl_securityGroup { get; set; }

        public virtual tbl_securityUserPermission tbl_securityUserPermission { get; set; }
        
    }
}
