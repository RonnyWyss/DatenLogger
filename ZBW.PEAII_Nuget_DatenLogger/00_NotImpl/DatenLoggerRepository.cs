namespace ZBW.PEAII_Nuget_DatenLogger.Repositories
{
    public class DatenLoggerRepository
    {
        //public DatenLoggerRepository(string connString) : base(connString)
        //{
        //}

        //public DatenLoggerRepository()
        //{
        //}

        //public void AddLogEntry(IEntity entity)
        //{
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();
        //        var procedureName = "logMessageAdd";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        //        {
        //            var p1 = new MySqlParameter("i_pod", entity.DeviceId); //char(36)
        //            p1.Direction = ParameterDirection.Input;
        //            p1.DbType = DbType.String;
        //            var p2 = new MySqlParameter("i_hostname", entity.Hostname); //varchar(50)
        //            p2.Direction = ParameterDirection.Input;
        //            p2.DbType = DbType.String;
        //            var p3 = new MySqlParameter("i_severity", entity.Severity); //char(36)
        //            p3.Direction = ParameterDirection.Input;
        //            p3.DbType = DbType.Int32;
        //            var p4 = new MySqlParameter("i_message", entity.Message); //varchar(2000)
        //            p4.Direction = ParameterDirection.Input;
        //            p4.DbType = DbType.String;
        //            var p5 = new MySqlParameter("i_location", entity.Location); //varchar(2000)
        //            p5.Direction = ParameterDirection.Input;
        //            p5.DbType = DbType.String;

        //            cmd.Parameters.Add(p1);
        //            cmd.Parameters.Add(p2);
        //            cmd.Parameters.Add(p3);
        //            cmd.Parameters.Add(p4);
        //            cmd.Parameters.Add(p5);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void ClearLogEntry(IEntity entity)
        //{
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();

        //        var procedureName = "LogClear";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        //        {
        //            var p1 = new MySqlParameter("_logentries_id", entity.Id);
        //            p1.Direction = ParameterDirection.Input;
        //            p1.DbType = DbType.Int32;
        //            cmd.Parameters.Add(p1);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}


        //public List<IEntity> GetAllLogEntries()
        //{
        //    var logEntries = new List<IEntity>();
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();

        //        var statement =
        //            "select id, pod, location, hostname, severity, timestamp, message from v_logentries order by timestamp";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        //        {
        //            using (var r = cmd.ExecuteReader())
        //            {
        //                while (r.Read())
        //                {
        //                    IEntity entity = new LogEntry(r.GetString(3), r.GetString(6), r.GetInt32(4), r.GetString(2));
        //                    entity.Id = r.GetInt32(0);
        //                    entity.Pod = r.GetString(1);
        //                    // entity.Location = r.GetString(2);
        //                    entity.Timestamp = r.GetDateTime(5);
        //                    logEntries.Add(entity);
        //                }
        //            }
        //        }
        //    }

        //    return logEntries;
        //}


        //public ObservableCollection<string> GetAllHostname()
        //{
        //    var hostnames = new ObservableCollection<string>();
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();

        //        var statement =
        //            "select  hostname  from device";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        //        {
        //            using (var r = cmd.ExecuteReader())
        //            {
        //                while (r.Read())
        //                    for (var i = 0; i < r.FieldCount; i++)
        //                        hostnames.Add(r.GetString(i));
        //            }
        //        }
        //    }

        //    return hostnames;
        //}

        //public ObservableCollection<string> GetAllLocation()
        //{
        //    var location = new ObservableCollection<string>();
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();

        //        var statement =
        //            "select location from v_logentries";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        //        {
        //            using (var r = cmd.ExecuteReader())
        //            {
        //                while (r.Read())
        //                    for (var i = 0; i < r.FieldCount; i++)
        //                        location.Add(r.GetString(i));
        //            }
        //        }
        //    }

        //    return location;
        //}

        //public ObservableCollection<int> GetAllSeverity()
        //{
        //    var severity = new ObservableCollection<int>();
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();

        //        var statement =
        //            "select severity from v_logentries";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        //        {
        //            using (var r = cmd.ExecuteReader())
        //            {
        //                while (r.Read())
        //                    for (var i = 0; i < r.FieldCount; i++)
        //                        severity.Add(r.GetInt32(i));
        //            }
        //        }
        //    }

        //    return severity;
        //}

        //public ObservableCollection<int> GetAllDeviceIds()
        //{
        //    var deviceIds = new ObservableCollection<int>();
        //    using (var conn = MySqlConnection)
        //    {
        //        conn.Open();

        //        var statement =
        //            "select  device_id  from device";
        //        using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        //        {
        //            using (var r = cmd.ExecuteReader())
        //            {
        //                while (r.Read())
        //                    for (var i = 0; i < r.FieldCount; i++)
        //                        deviceIds.Add(r.GetInt32(i));
        //            }
        //        }
        //    }

        //    return deviceIds;
        //}
    }
}