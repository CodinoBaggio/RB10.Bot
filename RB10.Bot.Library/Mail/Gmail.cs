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
        public static void Send(string toMailAddress, string password)
        {
            var fromAddress = new MailAddress("codino.baggio10@gmail.com", "BOTマスター");
            var toAddress = new MailAddress(toMailAddress);
            string fromPassword = password;
            const string subject = "商品が見つかりました。";
            const string body = "お探しの商品が見つかりました。\nカートに入っているか、すでに購入済みです。";

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
