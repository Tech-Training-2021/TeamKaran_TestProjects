using MediatR;
using System;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
