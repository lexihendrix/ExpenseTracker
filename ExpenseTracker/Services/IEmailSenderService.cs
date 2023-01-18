namespace ExpenseTracker.Services;

public interface IEmailSenderService
{
    void SendEmail(string fromName, string header, string message, string email);
}