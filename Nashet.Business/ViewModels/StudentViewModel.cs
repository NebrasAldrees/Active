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

        [StringLength(10)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("رقم الطالب المرجعي")]
        public string AcademicId { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName(" اسم الطالب باللغة العربية")]
        public string StudentNameAr { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName(" اسم الطالب باللغة الإنجليزية")]
        public string StudentNameEn { get; set; }

        [StringLength(150)]
        [DisplayName("البريد الإلكتروني")]
        public string StudentEmail { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("رقم الجوال")]
        public string StudentPhone { get; set; }

        [StringLength(50)]
        [DisplayName(" الجهة")]
        public int SiteId { get; set; }
        public SiteViewModel Site { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName(" مهارات الطالب")]
        public string StudentSkills { get; set; }
        
        public Guid Guid { get; set; }
        //public List<SiteViewModel> Sites { get; set; }


    }
}
