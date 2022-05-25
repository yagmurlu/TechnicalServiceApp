using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserSurname { get; set; }
        [StringLength(200)]
        public string UserImage { get; set; }
        [StringLength(100)]
        public string UserAbout { get; set; }
        [StringLength(50)]
        public string UserMail { get; set; }
        [StringLength(20)]
        public string UserPassword { get; set; }
        [StringLength(20)]
        public string UserNewPassword { get; set; }
        
    }
}
