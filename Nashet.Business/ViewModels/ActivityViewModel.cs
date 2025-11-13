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
    public class ActivityViewModel
    {
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("النادي التابع للنشاط")]
        public int ClubId { get; set; }
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("النادي التابع للنشاط")]
        public Guid ClubGuid { get; set; }
        public tblClub Club { get; set; }

        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("عنوان النشاط")]
        [StringLength(50)]
        public string ActivityTopic { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("تفاصيل النشاط")]
        public string ActivityDescription { get; set; }

        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("تاريخ بدء النشاط")]
        public DateTime ActivityStartDate { get; set; }
        [Required(ErrorMessage = "وقت البداية مطلوب")]
        public string ActivityStartTime { get; set; }


        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("تاريخ انتهاء النشاط")]
        public DateTime ActivityEndDate { get; set; }
        [Required(ErrorMessage = "وقت النهاية مطلوب")]
        public string ActivityEndTime { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "*حقل مطلوب*")]
        [DisplayName("موقع النشاط")]
        public string ActivityLocation { get; set; }

        [StringLength(1500)]
        [DisplayName("إرفاق صورة")]
        public string ActivityPoster { get; set; }
        public Guid Guid { get; set; }


    }
}
