using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblTeam : Common
    {
        [Key] 
        public int TeamId { get; set; }
        public int ClubId { get; set; }
        public tblClub Club { get; set; }
        [StringLength(50)]
        public string TeamNameAR { get; set; }
        [StringLength(50)]
        public string TeamNameEn { get; set; }
    }
}
