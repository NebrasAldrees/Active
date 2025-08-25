using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblStudent : Common
    {
        [Key]
        public int StudentId { get; set; }
        public int AcademicId { get; set; }

        [StringLength(50)]
        public string StudentNameAr { get; set; }

        [StringLength(50)]
        public string StudentNameEn { get; set; }

        [StringLength(50)]
        public string StudentEmail { get; set; }
        public int StudentPhone { get; set; }
        public int SiteId { get; set; }
        public tblSite Site { get; set; }

        [StringLength(150)]
        public string StudentSkills { get; set; }
    }
}
