namespace Core.Mailing;

public interface IMailService
{
    void SendMail(Mail mail);
    Task SendMailAsync(Mail mail);
}