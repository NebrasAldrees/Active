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
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("رقم الطالب المرجعي")]
        public int AcademicId { get; set; }
        public tblStudent StudentNameAr { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName(" اسم الطالب باللغة العربية")]
        public int StudentNameEn { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName(" اسم الطالب باللغة الإنجليزية")]
        public tblClubRole StudentEmail { get; set; }

        [StringLength(50)]
        [DisplayName("البريد الإلكتروني")]
        public int StudentPhone { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("رقم الجوال")]
        public tblTeam SiteId { get; set; }

        public tblSite Site { get; set; }
        [StringLength(50)]
        [DisplayName(" الجهة")]

        public string StudentSkills { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName(" مهارات الطالب")]
        public Guid Guid { get; set; }


    }
}
