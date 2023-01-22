namespace ExpenseTracker.Services;

public interface IEmailSenderService
{
    void SendEmailToCustomer(string fromName, string header, string message, string email);
    void EmailFromCustomer(string fromName, string header, string message, string email);

}