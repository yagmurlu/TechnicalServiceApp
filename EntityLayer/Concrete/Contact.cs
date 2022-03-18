using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {     
        [Key]
        public int ContactId { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; } //Gönderen
        [StringLength(50)]
        public string RecevierMail { get; set; } //Alıcı
        [StringLength(50)]
        public string Heading { get; set; } // Konu Başlığı
        [StringLength(500)]
        public string Contents { get; set; } // Mesaj İçeriği
        public DateTime ContactDate { get; set; } //Mesaj Gönderim Tarihi
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Todo> Todos { get; set; } // İlişkilendirme

    }
}
