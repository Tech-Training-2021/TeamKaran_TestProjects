using MediatR;
using System.Collections.Generic;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
