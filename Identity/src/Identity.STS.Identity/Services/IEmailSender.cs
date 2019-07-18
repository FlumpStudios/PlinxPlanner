using System.Threading.Tasks;

namespace Identity.STS.Identity.Services
{
        public interface IEmailSender
        {
            Task SendEmailAsync(string email, string subject, string message);
        }
}
