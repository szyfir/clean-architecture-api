using CleanArchitecture.Core.Application.Contracts.Infrastructure;
using CleanArchitecture.Core.Application.Models.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Mail
{
    public class MailService : IEmailService
    {
        //Options AppSettings

        public async Task SendEmail(Email email)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(email.FromAddress));
            mimeMessage.To.Add(MailboxAddress.Parse(email.ToAddress));
            mimeMessage.Subject = email.Topic;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Body };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("jedidiah.kuhn@ethereal.email", "r5RHyCDNfhbA5dt2VW");
                await smtp.SendAsync(mimeMessage);
                await smtp.DisconnectAsync(true);
            }

            await Task.CompletedTask;
        }
    }
}
