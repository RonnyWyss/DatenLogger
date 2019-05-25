using System;
using System.Collections;
using System.Dynamic;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    public interface IEntity : DuplicateCheckerLib.IEntity
    {
        int Id { get; set; }
        string DeviceId { get; set; }
        string Pod { get; set; }
        string Location { get; set; }
        string Hostname { get; set; }
        int Severity { get; set; }
        DateTime Timestamp { get; set; }
        string Message { get; set; }
    }
}