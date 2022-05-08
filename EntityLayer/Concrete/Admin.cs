using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string AdminName { get; set; }
        [StringLength(50)]
        public string AdminSurname { get; set; }
        [StringLength(200)]
        public string AdminImage { get; set; }
        [StringLength(50)]
        public string AdminMail { get; set; }
        [StringLength(20)]
        public string AdminPassword { get; set; }
    }
}

