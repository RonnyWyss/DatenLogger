using System;
using ZBW.PEAII_Nuget_DatenLogger.ViewModel;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    internal class LogEntry : ILogEntry
    {
        public LogEntry()
        {
        }

        public LogEntry(DatenLoggerAddViewModel datenLoggerAddViewModel)
        {
            Id = datenLoggerAddViewModel.Id;
            Pod = datenLoggerAddViewModel.Pod;
            Location = datenLoggerAddViewModel.Location;
            Hostname = datenLoggerAddViewModel.Hostname;
            Severity = datenLoggerAddViewModel.Severity;
            Timestamp = datenLoggerAddViewModel.Timestamp;
            Message = datenLoggerAddViewModel.Message;
        }

        public int Severity { get; set; }
        
        public int Id { get; set; }

        public string Pod { get; set; }

        public string Location { get; set; }

        public string Hostname { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}