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
    public class ClubRoleViewModel
    {
        public int ClubRoleId { get; set; }

        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("نوع المستخدم")]
        public  string RoleTypeAr { get; set; }
        public  string RoleTypeEn { get; set; }
        
        public Guid Guid { get; set; }


    }
}
