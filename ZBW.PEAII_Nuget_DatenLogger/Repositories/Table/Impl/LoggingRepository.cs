using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    internal class LoggingRepository : MySqlRepositoryBase<ILogging>, ILoggingRepository
    {
        public override string TableName => "Logging";

        protected override ILogging CreateEntity(IDataReader r)
        {
            var entity = new Logging();
            entity.Id = r.GetInt32(0);
            entity.Name = r.GetString(1);
            entity.Fk_Adress = r.GetInt32(2);
            entity.Building = r.GetString(3);
            entity.ParentId = r.GetInt32(4);

            return entity;
        }
        public void AddLogEntry(IEntity entity)
        {
            var inputKeys = new List<MySqlParameter>
            {
                new MySqlParameter("in_deviceId", entity.DeviceId),
                new MySqlParameter("in_hostname", entity.Hostname),
                new MySqlParameter("in_serverity", entity.Severity),
                new MySqlParameter("in_message", entity.Message)
            };
            var dbTypes = new List<DbType> { DbType.Int32, DbType.String, DbType.Int32, DbType.String };
            ExecuteStoreProcedur("logMessageAdd", inputKeys, dbTypes);
        }
        public void ClearLogEntry(IEntity entity)
        {
            var inputKeys = new List<MySqlParameter> { new MySqlParameter("id", entity.Id) };

            var dbTypes = new List<DbType> { DbType.Int32 };
            ExecuteStoreProcedur("LogClear", inputKeys, dbTypes);
        }

    }
}