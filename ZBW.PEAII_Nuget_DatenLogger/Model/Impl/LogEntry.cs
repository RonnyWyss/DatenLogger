using System;
using System.Reflection;
using Prism.Mvvm;
using ZBW.PEAII_Nuget_DatenLogger.ViewModel;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
     class LogEntry : BindableBase, ILogEntry
    {

        private int _id;

        public LogEntry(string hostename, string message, int severity)
        {
            Hostname = hostename;
            Message = message;
            Severity = severity;
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

        // public int Id { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);

                RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public string Pod { get; set; }

        public string Location { get; set; }

        public string Hostname { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}