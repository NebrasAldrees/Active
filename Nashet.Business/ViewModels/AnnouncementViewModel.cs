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
    public class AnnouncementViewModel
    {
        public int AnnouncementId { get; set; }
        public int ClubId { get; set; }
        public tblClub Club { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("نوع الإعلان")]
        [StringLength(50)]
        public int siteId { get; set; }
        public tblSite Site { get; set; }
        [DisplayName("اسم النادي")]
        [StringLength(50)]
        public string ClubNameAR { get; set; }
        public string AnnouncementType { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("موضوع الإعلان")]
        [StringLength(50)]
        public string AnnouncementTopic { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("تفاصيل الإ‘علان")]
        [StringLength(500)]
        public string AnnouncementDetails { get; set; }
        
        [DisplayName("صورة الإعلان")]
        public string AnnouncementImage { get; set; }
        public Guid Guid { get; set; }
    }
}
