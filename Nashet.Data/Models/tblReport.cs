using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblReport : Common
    {
        public int ReportId { get; set; }
        public int ClubId { get; set; }
        public tblClub Club { get; set; }
        [StringLength(50)]
        public string Topic { get; set; }
        [StringLength(50)]
        public string Path { get; set; }
        public bool IsAdded { get; set; }
    }
}
