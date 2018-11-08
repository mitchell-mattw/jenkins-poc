using System.Threading.Tasks;

namespace MongoIDM.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
