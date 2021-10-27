using MediatR;
using System;

namespace VoIP_CustomerPortal.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public string EventId { get; set; }
    }
}
