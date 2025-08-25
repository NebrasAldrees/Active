using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class tblSystemLogs : Common
    {
        [Key]
        public int LogsId { get; set; }
        public int UserId { get; set; }
        public tblUser User { get; set; }

        [StringLength(10)]
        public string username { get; set; }

        [StringLength(30)]
        public string Table { get; set; }
        public int RecordId { get; set; }

        [StringLength(200)]
        public string operation_type { get; set; }

        public DateTime operation_date { get; set; }

        [StringLength(500)]
        public string OldValue { get; set; }

        [StringLength(500)]
        public string NewValue { get; set; }

        [StringLength(200)]
        public string other_details { get; set; }


    }
}
