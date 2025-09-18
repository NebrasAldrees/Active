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
        [Key] public int? SystemRoleId { get; set; }
        
        public string RoleType { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المنصب")]

        public Guid guid { get; set; }

    }
}
