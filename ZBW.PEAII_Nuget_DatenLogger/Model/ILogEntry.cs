﻿using System;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
   public interface ILogEntry
    {
        int Id { get; set; }
        string Pod { get; set; }
        string Location { get; set; }
        string Hostname { get; set; }
        int Severity { get; set; }
        DateTime Timestamp { get; set; }
        string Message { get; set; }
    }
}