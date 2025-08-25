using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblSystemNotification : Common
    {
        [Key ]
        public int SystemNotificationId { get; set; }
        public DateTime date { get; set; }
        public DateTime Time { get; set; }

    }

}
