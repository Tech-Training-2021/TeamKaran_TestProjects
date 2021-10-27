using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoIP_CustomerPortal.Application.Contracts.Infrastructure;
using VoIP_CustomerPortal.Application.Models.Mail;
using VoIP_CustomerPortal.Infrastructure.Mail;

namespace VoIP_CustomerPortal.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
