using ZBW.PEAII_Nuget_DatenLogger.Model;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table
{
  interface ILoggingRepository
    {
        void AddLogEntry(IEntity entity);

        void ClearLogEntry(IEntity entity);

        void SetConnectionString(string connString);
    }
}