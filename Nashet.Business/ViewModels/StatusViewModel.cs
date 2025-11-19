using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class StatusViewModel
    {
        public int StatusId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName(" حالة الطلب باللغة العربية")]
        public string StatusTypeAr { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName(" حالة الطلب باللغة الإنجليزية")]
        public string StatusTypeEn { get; set; }
        public Guid guid { get; set; }
    }
}
