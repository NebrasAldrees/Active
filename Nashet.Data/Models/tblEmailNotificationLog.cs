using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblEmailNotificationLog : Common
    {
        [Key ]
       public int EmailNotificationsId { get; set; }

        [StringLength(30)]
        public string UserEmail { get; set; }
       
        

    }
}
