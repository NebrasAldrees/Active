using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class KfuUserViewModel
    {
        public int? KFUUserId { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المستخدم")]
        public string Username { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("كلمة المرور")]
        public string Password { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("نوع المستخدم")]
        public string UserType { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الاسم بالعربي")]
        public string NameAR { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الاسم بالإنجليزي")]
        public string NameEN { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("البريد الإلكتروني")]
        public string UserEmail { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم الجوال")]
        public string UserPhone { get; set; }
        public Guid guid { get; set; }
    }
}
