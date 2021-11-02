using System.Threading.Tasks;
using CarManagement.Application.Models.Mail;

namespace CarManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        public abstract Task<bool> SendEmail(Email email);
    }
}