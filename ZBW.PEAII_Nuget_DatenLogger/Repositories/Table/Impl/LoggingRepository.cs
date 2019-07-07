using LinqToDB.Data;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    public class LoggingRepository : MySqlRepositoryBase<LoggingDTO, int>, ILoggingRepository
    {
        private const string LogClear = "LogClear";
        private const string LogMessageAdd = "logMessageAdd";

        public void AddLogEntry(IEntity entry)
        {
            var dataParams = new DataParameter[4];
            dataParams[0] = new DataParameter("in_deviceId", entry.DeviceId);
            dataParams[1] = new DataParameter("in_hostname", entry.Hostname);
            dataParams[2] = new DataParameter("in_serverity", entry.Severity);
            dataParams[3] = new DataParameter("in_message", entry.Message);
            ExecuteStoreProcedur(LogMessageAdd, dataParams);
        }

        public void ClearLogEntry(IEntity entry)
        {
            var param = new DataParameter[1] {new DataParameter("id", entry.Id)};
            ExecuteStoreProcedur(LogClear, param);
        }
    }
}