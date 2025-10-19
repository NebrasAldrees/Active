using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblAnnouncement : Common
    {
        [Key]
        public int AnnouncementId { get; set; }
        public int? ClubId { get; set; }
        public tblClub Club { get; set; }
        public int? SiteId { get; set; }
        public tblSite Site { get; set; }
        [StringLength(50)]
        public string ClubNameAR { get; set; }

        [StringLength(50)]
        public string AnnouncementType { get; set; }

        [StringLength(50)]
        public string AnnouncementTopic { get; set; }

        [StringLength(500)]
        public string AnnouncementDetails { get; set; }
        public string AnnouncementImage { get; set; }

    }
}
