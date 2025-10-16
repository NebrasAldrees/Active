using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class SystemRoleViewModel 
    {
        public int SystemRoleId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("نوع المستخدم")]
        public string RoleTypeAr { get; set; }
        public string RoleTypeEn { get; set; }
        public Guid guid { get; set; }

    }
}
