using Shift.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Shift.Application.EventSourcedNormalizers
{
    public static class ConvenioHistory
    {
        public static IList<ConvenioHistoryData> HistoryData { get; set; }

        public static IList<ConvenioHistoryData> ToListConvenioHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ConvenioHistoryData>();
            ConvenioHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<ConvenioHistoryData>();
            var last = new ConvenioHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ConvenioHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Usuario = change.Usuario
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ConvenioHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<ConvenioHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "ConvenioAddedEvent":
                        historyData.Action = "Registered";
                        historyData.Usuario = e.User;
                        break;
                    case "ConvenioUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Usuario = e.User;
                        break;
                    case "ConvenioRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Usuario = e.User;
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Usuario = e.User ?? "Anonymous";
                        break;
                }
                HistoryData.Add(historyData);
            }
        }
    }
}