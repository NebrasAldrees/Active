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
    public class TeamViewModel
    {
        public int TeamId { get; set; }

        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("اسم النادي")]
        public int? ClubId { get; set; }
        public tblClub Club { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*هذا الحقل مطلوب*")]
        [DisplayName("اسم الفريق باللغة العربية")]
        public string TeamNameAR { get; set; }

        [StringLength(50)]
        [DisplayName("اسم الفريق باللغة الانجليزية")]
        public string TeamNameEn { get; set; }
        public Guid Guid { get; set; }
        public List<ClubViewModel> clubs { get; set; }


    }
}
