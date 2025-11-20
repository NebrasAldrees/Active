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
        [Key]
        public int ActivityRequestId { get; set; }
        public int ClubId { get; set; }
        public tblClub Club { get; set; }

        [StringLength(50)]
        public string ActivityTopic { get; set; }

        [StringLength(500)]
        public string ActivityDescription { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }

        [StringLength(300)]
        public string ActivityLocation { get; set; }

        [StringLength(200)]
        public string ActivityPoster { get; set; }
        public int StatusId { get; set; }
        public tblStatus Status { get; set; }
    }
}
