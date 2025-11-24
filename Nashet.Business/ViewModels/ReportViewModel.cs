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
    public class ReportViewModel
    {
        public int ReportId { get; set; }
        public int? ClubId { get; set; }
        public Guid ClubGuid { get; set; }
        public string ClubNameAr { get; set; }
        public tblClub Club { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("موضوع التقرير")]
        [StringLength(50)]
        public string Topic { get; set; }

        [DisplayName("مسار التقرير")]
        [StringLength(1500)]
        public string Path { get; set; }

        public Guid Guid { get; set; }

        [Display(Name = "ملف التقرير")]
        public IFormFile File { get; set; }

        public bool IsAdded { get; set; }

        public interface IFormFile
        {
        }
    }
}
