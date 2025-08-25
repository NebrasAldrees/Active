using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblMembership : Common
    {
        [Key]
        public int MembershipId { get; set; }
        public int StudentId { get; set; }
        public tblStudent Student { get; set; }
        public int ClubRoleId { get; set; }
        public tblClubRole ClubRole { get; set; }
        public int TeameId { get;set; }
        public tblTeam Team { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
