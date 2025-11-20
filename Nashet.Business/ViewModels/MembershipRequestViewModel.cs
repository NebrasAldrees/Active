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
    public class MembershipRequestViewModel
    {
        [Key] public int MRId { get; set; }

        public int StudentID { get; set; }
        public string AcademicId { get; set; }
        public tblStudent Student { get; set; }
        public int ClubID { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("النادي")]
        public Guid ClubGuid { get; set; }
        public tblClub Club { get; set; }
        public int? TeamID { get; set; }

        [DisplayName("الفريق")]
        public Guid? TeamGuid { get; set; }
        public tblTeam Team { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الرغبة الأولى")]
        public Guid RequestTeam1 { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الرغبة الثانية")]
        public Guid RequestTeam2 { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الرغبة الثالثة")]
        public Guid RequestTeam3 { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("سبب التقديم")]
        public string RequestReason { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("تاريخ تقديم الطلب")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public Guid Guid { get; set; }
        public string StatusTypeAr { get; set; }
        public int StatusId { get; set; }
        public Guid StatusGuid { get; set; }
        public tblStatus status { get; set; }

    }
}
