using MediatR;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommand : IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
