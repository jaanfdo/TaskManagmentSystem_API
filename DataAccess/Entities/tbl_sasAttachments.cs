namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class tbl_sasAttachments
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string transaction_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int attachment_Index { get; set; }

        public int? form_ID { get; set; }

        [StringLength(500)]
        public string attachment { get; set; }

        [StringLength(500)]
        public string dipsplayName { get; set; }

        public tbl_sasAttachments()
        {

        }

        public tbl_sasAttachments(string _transaction_ID, int _attachment_Index, int _form_ID, string _attachment, string _dipsplayName)
        {
            transaction_ID = _transaction_ID;
            attachment_Index = _attachment_Index;
            form_ID = _form_ID;
            attachment = _attachment;
            dipsplayName = _dipsplayName;
        }
    }
}
