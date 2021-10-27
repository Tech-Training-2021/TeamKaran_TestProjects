using CsvHelper;
using System.Collections.Generic;
using System.IO;
using VoIP_CustomerPortal.Application.Contracts.Infrastructure;
using VoIP_CustomerPortal.Application.Features.Events.Queries.GetEventsExport;

namespace VoIP_CustomerPortal.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
