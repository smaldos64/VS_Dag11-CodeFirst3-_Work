using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class MailHandlingTools
    {
        public static bool MailSender(string smtp, string from, string to, string subject, string message)
        {
            bool status = false;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                string htmlbody = message.ToString();
                mail.Body = htmlbody;
                smtpServer.Send(mail);

                return (status = true);
            }
            catch (Exception error)
            {
                return status;
            }
            // Her på skolen skal SMTP parameteren sættes til "10.138.22.47"
        }

    }
}