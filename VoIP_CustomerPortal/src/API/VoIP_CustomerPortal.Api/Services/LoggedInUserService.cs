using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using VoIP_CustomerPortal.Application.Contracts;

namespace VoIP_CustomerPortal.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
