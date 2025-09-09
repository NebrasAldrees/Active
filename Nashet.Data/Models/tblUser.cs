using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblUser : Common
    {

       [Key] public int UserId { get; set; }
        
        public int SystemRoleId { get; set; }
        [StringLength(30)]
        public tblSystemRole SystemRole { get; set; }
        [StringLength(50)]

        public string UserNameAR { get; set; }
        [StringLength(50)]
        public string UserNameEN { get; set; }
        [StringLength(50)]
        public string UserEmail { get; set; }
        [StringLength(30)]
        public int UserPhone { get; set; }
        
        public int SiteId { get; set; } 
        public tblSite Site { get; set; }
    }
}
