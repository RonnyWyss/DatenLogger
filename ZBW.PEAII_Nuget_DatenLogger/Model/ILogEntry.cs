using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    interface ILogEntry
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
