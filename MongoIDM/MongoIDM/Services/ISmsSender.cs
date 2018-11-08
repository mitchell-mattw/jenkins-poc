using System.Threading.Tasks;

namespace MongoIDM.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
