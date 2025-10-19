using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblActivityRequest:Common 
    {

        [Key] public int ARId { get; set; }
        public int? UserID { get; set; }
        public tblUser User { get; set; }
        public int? SiteID { get; set; }
        public tblSite Site { get; set; }
        public int? ClubID { get; set; }
        public tblClub Club { get; set; } 

        [StringLength(100)]
        public string ActivityTopic { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeOnly ActivityTime { get; set; }
        [StringLength(100)]
        public string ActivityLocation { get; set; }
        public string ActivityPoster { get; set; }
        public int ActivityRequestId { get; internal set; }
    }
}
