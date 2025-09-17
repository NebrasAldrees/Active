 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class SiteViewModel
    {
        public int SiteId { get; set; }

        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("رمز الجهة")]
        public int SiteCode { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("اسم الجهة باللغة العربية")]
        public string SiteNameAR { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("اسم الجهة باللغة الانجليزية")]
        public string SiteNameEn { get; set; }

        public Guid Guid { get; set; }

    }
}
