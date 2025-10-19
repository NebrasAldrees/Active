using Nashet.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class ReportViewModel
    {
            public int ReportId { get; set; }

            [Required(ErrorMessage = "*حقل مطلوب*")]
            [DisplayName("النادي")]
            public int ClubId { get; set; }

            [Required(ErrorMessage = "*حقل مطلوب*")]
            [DisplayName("عنوان التقرير")]
            [StringLength(200)]
            public string Topic { get; set; }

            [DisplayName("مسار الملف")]
            public string Path { get; set; }

            public bool IsAdded { get; set; }
            public Guid Guid { get; set; }
            public DateTime CreationDate { get; set; }
            public bool IsDeleted { get; set; }
            public bool IsActive { get; set; }
            public bool isSent { get; set; }
    }
}
