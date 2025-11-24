using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblSystemRole : Common
    {
        [Key] 
        public int SystemRoleId { get; set; }
        [StringLength(30)]
        public string RoleTypeAr { get; set; }

        public string RoleTypeEn { get; set; }
    }
}
