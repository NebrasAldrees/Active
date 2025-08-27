using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    internal class tblRequest :Common

    {
        [Key ]
        public int RequestId { get; set; }

        [StringLength(50)]
        public string SentBy { get; set; } // user id 
        public tblUser User { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }
        [StringLength(500)]
        public string AttachedFile { get; set; }

    }
}
