using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Models.Mail;

namespace VoIP_CustomerPortal.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
