using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblKFUuser : Common
    {
        [Key]
        public int KFUUserId { get; set; }
        [StringLength(10)]
        public string Username { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(30)]
        public string UserType { get; set; }
        [StringLength(50)]
        public string NameAR { get; set; }
        [StringLength(50)]
        public string NameEN { get; set; }
        [StringLength(50)]
        public string UserEmail { get; set; }
        [StringLength(30)]
        public string UserPhone { get; set; }
    }
}
