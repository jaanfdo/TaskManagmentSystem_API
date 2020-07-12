namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_securityGroup
    {
        [Key]
        [StringLength(10)]
        [DisplayName("Group Code")]
        public string group_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Group Name")]
        public string groupName { get; set; }

        public bool? is_Active { get; set; }

        public virtual ICollection<tbl_securityGroupPermission> tbl_securityGroupPermission { get; set; }

        public virtual ICollection<tbl_securityUserMaster> tbl_securityUserMaster { get; set; }
    }
}
