using System.Collections.Generic;
using VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventsExport;

namespace VoIP_CustomerPortal.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
