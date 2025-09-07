using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblRequest_type : Common

    {
        [Key]
        public int TypeId { get; set; }
        [StringLength(50)]
        public string TypeName { get; set; }
    }
}
