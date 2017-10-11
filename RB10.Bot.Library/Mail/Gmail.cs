using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library.Mail
{
    public class Gmail
    {
        public static void Send()
        {
            var fromAddress = new MailAddress("from-gmail-address-sample@gmail.com", "from name");
            var toAddress = new MailAddress("to-gmail-address-sample@gmail.com", "to name");
            const string fromPassword = "gmailPassword";
            const string subject = "GMAIL TITLE";
            const string body = "GMAIL BODY";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
