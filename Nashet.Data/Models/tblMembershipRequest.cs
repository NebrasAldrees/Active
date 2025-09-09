using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblMembershipRequest :Common
    {
        [Key] public int MRId { get; set; }
        
        public int StudentID { get; set; }
        public tblStudent Student { get; set; }
        public int ClubID { get; set; }
        public tblClub Club { get; set; }
        public int TeamID { get; set; }
        public tblTeam Team { get; set; }

        [StringLength(100)]
        public string RequestTeam1 { get; set; }
        [StringLength(100)]
        public string RequestTeam2 { get; set; }
        [StringLength(100)]
        public string RequestTeam3 { get; set; }
        [StringLength(1000)]
        public string RequestReason { get; set; }
        public DateTime RequestDate { get; set; }


        

    }
}
