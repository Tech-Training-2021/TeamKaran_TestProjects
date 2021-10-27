using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoIP_CustomerPortal.Application.Contracts.Persistence;
using VoIP_CustomerPortal.Application.Features.Orders.GetOrdersForMonth;
using VoIP_CustomerPortal.Application.Profiles;
using VoIP_CustomerPortal.Application.Responses;
using VoIP_CustomerPortal.Application.UnitTests.Mocks;
using Xunit;

namespace VoIP_CustomerPortal.Application.UnitTests.Orders.Queries
{
    public class GetOrdersForMonthQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOrderRepository> _mockOrderRepository;

        public GetOrdersForMonthQueryHandlerTests()
        {
            _mockOrderRepository = OrderRepositoryMocks.GetOrderRepositoryAsync();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_Orders_For_Month_Test()
        {
            var handler = new GetOrdersForMonthQueryHandler(_mockOrderRepository.Object, _mapper);

            var result = await handler.Handle(new GetOrdersForMonthQuery() { Date = Convert.ToDateTime("2021-08-26 10:44:09.5406918"), Page = 1, Size = 2 }, CancellationToken.None);

            result.ShouldBeOfType<PagedResponse<IEnumerable<OrdersForMonthDto>>>();
            result.Data.ShouldBeOfType<List<OrdersForMonthDto>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
