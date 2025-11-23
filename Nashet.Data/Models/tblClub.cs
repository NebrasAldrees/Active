using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblClub : Common
    {
        [Key]
        public int ClubId { get; set; }
        public int siteId{ get; set; }
        public tblSite Site { get; set; }

        [StringLength(150)]
        public string ClubNameAR { get; set; }
       [StringLength(150)]
        public string ClubNameEN { get; set; }

        [StringLength(500)]
        public string ClubVision { get; set; }
        [StringLength(500)]
        public string ClubOverview { get; set; }
        [StringLength(500)]
        public string ClubIcon { get; set; }
    }
}
