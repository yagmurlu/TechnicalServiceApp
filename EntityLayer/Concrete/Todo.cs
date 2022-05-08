using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
        public bool Done { get; set; } //yapıldı
        public bool Working { get; set; } // çalışıyor
        public bool Wait { get; set; } // beklemede ve ya silme olabilir.
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

    }
}
