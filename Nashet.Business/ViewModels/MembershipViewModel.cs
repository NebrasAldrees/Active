using Nashet.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("اسم الطالب")]
        public int ClubRoleId { get; set; }

        public tblClubRole ClubRole { get; set; }

        [StringLength(50)]
        [DisplayName("نوع عضوية الطالب")]
        public int TeamId { get; set; }

        public tblTeam Team { get; set; }
        [StringLength(50)]
        [DisplayName("الفريق")]

        public DateTime JoinDate { get; set; }
        [StringLength(50)]
        [DisplayName("تاريخ الإنضمام")]
        public Guid Guid { get; set; }

        
    }
}
