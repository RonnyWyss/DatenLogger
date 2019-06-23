using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.View.Impl
{
  public  class LogEntryView: MySqlRepositoryBase<IEntity>, ILogEntryView
  {
      public override string TableName => "v_logentries";

      public List<IEntity> GetAllLogEntries()
      {
          var allLogEntries = GetAll();

          return allLogEntries;
      }

      protected override IEntity CreateEntity(IDataReader r)
      {
          var entity = new LogEntry(r.GetString(3), r.GetString(6), r.GetInt32(4));
          entity.Id = r.GetInt32(0);
          entity.Pod = r.GetString(1);
          entity.Location = r.GetString(2);
          entity.Timestamp = r.GetDateTime(5);

          return entity;
      }
    }
}
