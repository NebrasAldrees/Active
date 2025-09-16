using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblSite : Common
    {
        [Key]
        public int SiteId { get; set; }
        public int SiteCode { get; set; }
        [StringLength(50)]
        public string SiteNameAR { get; set; }
        [StringLength(50)]
        public string SiteNameEn { get; set; }


    }
}
