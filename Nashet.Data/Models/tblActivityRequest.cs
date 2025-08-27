using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    internal class tblActivityRequest
    {

        [Key] public int ARId { get; set; }
        public int UserID { get; set; }
        public int SiteID { get; set; }
        public int ClubID { get; set; }
        [StringLength(100)]
        public string ActivityTopic { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeOnly ActivityTime { get; set; }
        [StringLength(100)]
        public string ActivityLocation { get; set; }
        public ImageFileMachine ActivityPoster { get; set; }

    }
}
