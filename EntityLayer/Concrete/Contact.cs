using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        [AllowHtml]
        public string Contents { get; set; } // Mesaj İçeriği
        public DateTime ContactDate { get; set; } //Mesaj Gönderim Tarihi
        public bool IsDraft { get; set; }
        public bool Trash { get; set; }
        public bool IsRead { get; set; }
        public bool ContactStatus { get; set; } // Admin veye kullanıcı mesajı silmek istedğinde 
        //mesaj tamamen silinmesin. Tablolarda yalnızca true olan mesajlar listelensin.

        public ICollection<Todo> Todos { get; set; } // İlişkilendirme

    }
}
