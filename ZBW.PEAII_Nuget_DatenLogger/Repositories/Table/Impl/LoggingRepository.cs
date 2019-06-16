using System.Data;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    internal class LoggingRepository : RepositoryBase<ILogging>, ILoggingRepository
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
    }
}