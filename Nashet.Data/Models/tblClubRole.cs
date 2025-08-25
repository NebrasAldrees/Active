﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblClubRole : Common
    {
        [Key]
        public int ClubRoleId { get; set; }

        [StringLength(50)]
        public string RoleType { get; set; }
    }
}
