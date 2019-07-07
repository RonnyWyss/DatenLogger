using System.Collections.Generic;
using System.Linq;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.View.Impl
{
    public  class LogEntryView : MySqlRepositoryBase<ViewLogEntryDTO, int>, ILogEntryView
    {
        public List<IEntity> GetAllLogEntries()
        {
            var allLogEntries = GetAll();

            var logentries = allLogEntries.Select(entries => (IEntity) new LogEntry(entries.Hostname, entries.Text, entries.Severity)
            {
                Id = entries.Id,
                Pod = entries.Pod,
                Location = entries.Location,
                Hostname =  entries.Hostname,
                Timestamp = entries.Timestamp
            }).ToList();

            return logentries;
        }
    }
}