using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Responses;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, Response<IEnumerable<CustomerListVm>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetCustomerListQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<GetCustomerListQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<CustomerListVm>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {           
            _logger.LogInformation("Handle Initiated");
            var allCustomers = (await _customerRepository.ListAllAsync()).OrderBy(x => x.Username);
            var customer = _mapper.Map<IEnumerable<CustomerListVm>>(allCustomers);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CustomerListVm>>(customer, "success");
        }
    }
}
