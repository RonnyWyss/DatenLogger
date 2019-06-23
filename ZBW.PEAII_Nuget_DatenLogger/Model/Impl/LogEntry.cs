using System;
using Prism.Mvvm;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    internal class LogEntry : BindableBase, IEntity
    {
        public LogEntry(string hostename, string message, int severity)
        {
            Hostname = hostename;
            Message = message;
            Severity = severity;
          //  Location = location;
            Timestamp = DateTime.Now;
        }

        public int Severity { get; set; }

        public int Id { get; set; }

        public string DeviceId { get; set; }

        public string Pod { get; set; }

        public string Location { get; set; }

        public string Hostname { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }

        public override bool Equals(object value)
        {
            return Equals(value as LogEntry);
        }

        public bool Equals(LogEntry entity)
        {
            if (ReferenceEquals(null, entity)) return false;

            if (ReferenceEquals(this, entity)) return true;

            return Equals(Severity, entity.Severity) && string.Equals(Message, entity.Message);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int) 2166136261;
                const int HashingMultiplier = 16777619;
                var hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Severity) ? Severity.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Message) ? Message.GetHashCode() : 0);

                return hash;
            }
        }

        public static bool operator ==(LogEntry entityA, LogEntry entityB)
        {
            if (ReferenceEquals(entityA, entityB)) return true;

            if (ReferenceEquals(null, entityA)) return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(LogEntry entityA, LogEntry entityB)
        {
            return !(entityA == entityB);
        }
    }
}