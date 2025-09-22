using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class EmailNotificationViewModel
    {
        public int EmailNotificationsId { get; set; }

        [StringLength(30)]
        public string UserEmail { get; set; }

       // public Guid guid { get; set; }

    }
}
