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
        public int ClubId { get; set; }
        public tblClub Club { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("موضوع التقرير")]
        [StringLength(50)]
        public string Topic { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("إرفاق التقرير")]
        [StringLength(50)]
        public string Path { get; set; }
        public Guid Guid { get; set; }
        public bool IsAdded { get; set; }
    }
}
