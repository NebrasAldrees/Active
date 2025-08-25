using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class Common
    {
        
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool is_sent { get; set; } = true;

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(30)]
        public string content { get; set; }
    }
}
