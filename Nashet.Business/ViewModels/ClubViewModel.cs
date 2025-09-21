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
    public class ClubViewModel
    {
        public int ClubId { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("اسم الجهة")]
        public int? siteId { get; set; }
        public tblSite Site { get; set; }

        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("اسم النادي باللغة العربية")]
        [StringLength(50)]
        public string ClubNameAR { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("اسم النادي باللغة الإنجليزية")]
        [StringLength(50)]
        public string ClubNameEN { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("الرؤية")]
        [StringLength(500)]
        public string ClubVision { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("نبذة عن النادي")]
        [StringLength(500)]
        public string ClubOverview { get; set; }
        [StringLength(500)]
        public string ClubIcon { get; set; }
        public Guid Guid { get; set; }
    }
}
