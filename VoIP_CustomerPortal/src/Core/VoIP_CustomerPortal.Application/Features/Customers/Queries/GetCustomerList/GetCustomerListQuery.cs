using MediatR;
using System.Collections.Generic;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<Response<IEnumerable<CustomerListVm>>>
    {
    }
}
