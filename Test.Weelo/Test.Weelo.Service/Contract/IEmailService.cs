using System.Threading.Tasks;
using Test.Weelo.Domain.Settings;

namespace Test.Weelo.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
