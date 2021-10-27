using System;
using System.Collections.Generic;
using VoIP_CustomerPortal.Domain.Common;

namespace VoIP_CustomerPortal.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
