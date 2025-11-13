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
        public int ClubId { get; set; }
        public tblClub Club { get; set; }
                
        [StringLength(150)]
        public string AnnouncementType { get; set; }

        [StringLength(150)]
        public string AnnouncementTopic { get; set; }

        [StringLength(500)]
        public string AnnouncementDetails { get; set; }
        [StringLength(1500)]
        public string AnnouncementImage { get; set; }

    }
}
