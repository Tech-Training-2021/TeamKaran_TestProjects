using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VoIP_CustomerPortal.Application.Contracts.Infrastructure;
using VoIP_CustomerPortal.Application.Models.Mail;

namespace VoIP_CustomerPortal.Application.UnitTests.Mocks
{
    public class EmailServiceMocks
    {
        public static Mock<IEmailService> GetEmailService()
        {
            var mockEmailService = new Mock<IEmailService>();
            mockEmailService.Setup(x => x.SendEmail(It.IsAny<Email>())).ReturnsAsync(true);
            return mockEmailService;
        }
    }
}
