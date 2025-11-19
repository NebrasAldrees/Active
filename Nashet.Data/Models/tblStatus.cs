using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblStatus:Common
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusTypeAr { get; set; }
        public string StatusTypeEn { get; set; }

    }
}
