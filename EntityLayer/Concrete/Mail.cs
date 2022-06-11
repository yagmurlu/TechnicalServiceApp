using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Mail
    {
        
        public static void MailSender(string body)
        {
           
           
            var fromMail = new MailAddress("aleyna@gmail.com");
            var toMail = new MailAddress("yagmur@gmail.com");
            const string subject = "İşleminiz tamamlandı";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, "100")
            })
            {
                using (var message = new MailMessage(fromMail, toMail) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}
