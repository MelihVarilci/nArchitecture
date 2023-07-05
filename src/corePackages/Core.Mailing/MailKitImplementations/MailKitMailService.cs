using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Core.Mailing.MailKitImplementations;

public class MailKitMailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailKitMailService(IConfiguration configuration)
    {
        _mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>()
                        ?? throw new ArgumentNullException(nameof(MailSettings));
    }

    public void SendMail(Mail mail)
    {
        MimeMessage email = new();

        email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));

        email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));

        email.Subject = mail.Subject;

        BodyBuilder bodyBuilder = new()
        {
            TextBody = mail.TextBody,
            HtmlBody = mail.HtmlBody
        };

        if (mail.Attachments is not null)
            foreach (MimeEntity? attachment in mail.Attachments)
                bodyBuilder.Attachments.Add(attachment);

        email.Body = bodyBuilder.ToMessageBody();

        using SmtpClient smtp = new();
        smtp.Connect(_mailSettings.Server, _mailSettings.Port);
        //smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }

    public async Task SendMailAsync(Mail mail)
    {
        MimeMessage mailToSend = new();

        mailToSend.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));
        mailToSend.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));

        mailToSend.Subject = mail.Subject;
        BodyBuilder bodyBuilder = new()
        {
            TextBody = mail.TextBody,
            HtmlBody = mail.HtmlBody
        };
        if (mail.Attachments is not null)
        {
            foreach (MimeEntity? attachment in mail.Attachments)
            {
                bodyBuilder.Attachments.Add(attachment);
            }
        }
        mailToSend.Body = bodyBuilder.ToMessageBody();

        using SmtpClient smtpClient = new();
        await smtpClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port);
        //await smtpClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password); // Test Smtp Server'ı kullandığımız ve Authenticate gerekmediği için yorum satırına aldık.

        await smtpClient.SendAsync(mailToSend);

        await smtpClient.DisconnectAsync(quit: true);
    }
}