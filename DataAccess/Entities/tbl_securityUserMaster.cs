namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_securityUserMaster
    {
        [Key]
        [StringLength(20)]
        [DisplayName("User Code")]
        public string user_ID { get; set; }

        [StringLength(50)]
        [DisplayName("User Name")]
        public string userName { get; set; }

        [StringLength(50)]
        [DisplayName("Password")]
        public string password { get; set; }

        [StringLength(50)]
        [DisplayName("Password 2")]
        public string password2 { get; set; }

        [StringLength(10)]
        [DisplayName("Employee Code")]
        public string employeeID { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(50)]
        [DisplayName("Mobile")]
        public string mobible { get; set; }

        [StringLength(50)]
        public string computerName { get; set; }

        [StringLength(50)]
        public string computerIP { get; set; }

        public DateTime? lastLogedDateTime { get; set; }

        public bool? isLoged { get; set; }

        public bool? isBlocked { get; set; }

        public bool? isLocked { get; set; }

        [StringLength(10)]
        public string group_ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        public DateTime? lastPWChangedDateTime { get; set; }

        [StringLength(20)]
        public string lastPWChangedUser_ID { get; set; }

        [StringLength(50)]
        public string lastPWChangedTerminal_ID { get; set; }

        [StringLength(100)]
        [DisplayName("Loged User Code")]
        public string userLoged_ID { get; set; }

        public virtual tbl_securityGroup tbl_securityGroup { get; set; }
    }
}
