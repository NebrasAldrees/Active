using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    internal class tblPositionRequest:Common
    {
         [Key] public int PRId { get; set; }
         public int MembershipID { get; set; }
         public int ClubRoleID { get; set; }
         public string RequestedPosition { get; set; }
         public DateTime RequestedDate { get; set; }
        

    }
}
