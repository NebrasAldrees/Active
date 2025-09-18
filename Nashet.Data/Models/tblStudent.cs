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
        [StringLength(10)]
        public string AcademicId { get; set; }

        [StringLength(150)]
        public string StudentNameAr { get; set; }

        [StringLength(150)]
        public string StudentNameEn { get; set; }

        [StringLength(150)]
        public string StudentEmail { get; set; }
        [StringLength(10)]
        public string StudentPhone { get; set; }
        public int SiteId { get; set; }
        public tblSite Site { get; set; }

        [StringLength(250)]
        public string StudentSkills { get; set; } //update 
    }
}
