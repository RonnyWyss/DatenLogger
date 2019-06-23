using System.Collections.Generic;
using ZBW.PEAII_Nuget_DatenLogger.Model;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.View
{
    public interface ILogEntryView
    {
        List<IEntity> GetAllLogEntries();

        void SetConnectionString(string connString);
    }
}