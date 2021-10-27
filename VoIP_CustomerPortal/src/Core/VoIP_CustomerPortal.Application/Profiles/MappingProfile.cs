using AutoMapper;
using VoIP_CustomerPortal.Application.Features.Categories.Commands.CreateCateogry;
using VoIP_CustomerPortal.Application.Features.Categories.Queries.GetCategoriesList;
using VoIP_CustomerPortal.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using VoIP_CustomerPortal.Application.Features.Customers.Queries.GetCustomerList;
using VoIP_CustomerPortal.Application.Features.Events.Commands.CreateEvent;
using VoIP_CustomerPortal.Application.Features.Events.Commands.UpdateEvent;
using VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventDetail;
using VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventsExport;
using VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventsList;
using VoIP_CustomerPortal.Application.Features.Orders.GetOrdersForMonth;
using VoIP_CustomerPortal.Application.Features.Roles.Commands.CreateRole;
using VoIP_CustomerPortal.Application.Features.Roles.Commands.UpdateRole;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleListWithUsers;
using VoIP_CustomerPortal.Application.Features.Users.Queries.GetUserList;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();            
            CreateMap<Event, EventExportDto>().ReverseMap();
            
            CreateMap<User, RoleUserDto>().ReverseMap();

            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<Role, UpdateRoleCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
            //CreateMap<Role, RoleListVm>().ConvertUsing<RoleVmCustomMapper>();

            CreateMap<Role, RoleUserDto>();
            CreateMap<Role, RoleListVm>();
            CreateMap<Role, RoleUserListVm>();
            CreateMap<Role, CreateRoleCommand>();
            CreateMap<Role, CreateRoleDto>();

            CreateMap<User, UserListVm>();

            CreateMap<Customer, CustomerListVm>();
        }
    }
}
