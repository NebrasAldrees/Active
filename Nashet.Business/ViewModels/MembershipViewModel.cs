using Nashet.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class MembershipViewModel
    {
        public int MembershipId { get; set; }


        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("رقم الطالب المرجعي")]
        public int StudentId { get; set; }
        public tblStudent Student { get; set; }

        
        [DisplayName("نوع عضوية الطالب")]
        public int ClubRoleId { get; set; }
        public tblClubRole ClubRole { get; set; }

        
        [DisplayName("الفريق")]
        public int TeamId { get; set; }
        public tblTeam Team { get; set; }

        
        [DisplayName("تاريخ الإنضمام")]
        public DateTime JoinDate { get; set; }
        public Guid Guid { get; set; }


        [NotMapped]
        [DisplayName("الرقم الأكاديمي")]
        public string AcademicId { get; set; }
    }
}
