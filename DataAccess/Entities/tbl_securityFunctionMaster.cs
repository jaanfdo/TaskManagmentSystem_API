using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class tbl_securityFunctionMaster
    {
        [Key]
        [StringLength(10)]
        public string function_ID { get; set; }

        [StringLength(100)]
        public string displayName { get; set; }

        public int counter { get; set; }
        public int length { get; set; }

        [StringLength(20)]
        public string prefix1 { get; set; }
        public bool isAutoGenerate { get; set; }

    }

    
}