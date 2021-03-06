using MediatR;
using System;
using VoIP_CustomerPortal.Application.Responses;

namespace VoIP_CustomerPortal.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
