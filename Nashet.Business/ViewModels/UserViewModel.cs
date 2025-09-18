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
    public class UserViewModel  
    {

        public int UserId { get; set; }

        public int SystemRoleId { get; set; }
        [StringLength(30)]
        
        public tblSystemRole SystemRole { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("نوع المستخدم")]

        public string UserNameAR { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المستخدم بالعربي")]

        public string UserNameEN { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المستخدم بالانجليزي")]
        public string UserEmail { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName(" البريد الإلكتروني")]
        public string UserPhone { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم الهاتف")]

        public int? SiteId { get; set; }
        public tblSite Site { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الجهة")]
        public Guid guid { get; set; }
    }
}
