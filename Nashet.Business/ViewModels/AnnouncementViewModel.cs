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
        [DisplayName("اسم النادي")]
        [Required(ErrorMessage = "*حقل مطلوب*")]
        public int ClubId { get; set; }
        [DisplayName("اسم النادي")]
        public Guid ClubGuid { get; set; }
        public tblClub Club { get; set; }
       
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("نوع الإعلان")]
        [StringLength(150)]
        public string AnnouncementType { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("موضوع الإعلان")]
        [StringLength(150)]
        public string AnnouncementTopic { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("تفاصيل الإعلان")]
        [StringLength(500)]
        public string AnnouncementDetails { get; set; }
        
        [DisplayName("إرفاق صورة للإعلان")]
        [StringLength(1500)]
        public string AnnouncementImage { get; set; }
        public Guid Guid { get; set; }
    }
}
