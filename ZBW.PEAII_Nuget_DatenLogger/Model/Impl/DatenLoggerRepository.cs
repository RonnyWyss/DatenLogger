using System.Collections.ObjectModel;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    public class DatenLoggerRepository : MySqlRepository
    {
        public DatenLoggerRepository(string connString) : base(connString)
        {
        }

        public DatenLoggerRepository()
        {
        }

        public void AddLogEntry(ILogEntry logEntry)
        {
            using (var conn = MySqlConnection)
            {
                conn.Open();
                var procedureName = "logMessageAdd";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
                {
                    var p1 = new MySqlParameter("in_GeraetID", logEntry.Id); //char(36)
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.Int32;
                    var p2 = new MySqlParameter("in_GeraetHostname", logEntry.Hostname);//varchar(50)
                    p2.Direction = ParameterDirection.Input;
                    p2.DbType = DbType.String;
                    var p3 = new MySqlParameter("in_LogLevelID", logEntry.Severity);//char(36)
                    p3.Direction = ParameterDirection.Input;
                    p3.DbType = DbType.Int32;
                    var p4 = new MySqlParameter("in_LogMessage", logEntry.Message);//varchar(2000)
                    p4.Direction = ParameterDirection.Input;
                    p4.DbType = DbType.String;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ClearLogEntry(ILogEntry logEntry)
        {
            using (var conn = MySqlConnection)
            {
                conn.Open();

                var procedureName = "LogClear";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
                {
                    var p1 = new MySqlParameter("_logentries_id", logEntry.Id);
                    p1.Direction = ParameterDirection.Input;
                    p1.DbType = DbType.Int32;
                    cmd.Parameters.Add(p1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ObservableCollection<int> GetAllDeviceIds()
        {
            var deviceIds = new ObservableCollection<int>();
            using (var conn = MySqlConnection)
            {
                conn.Open();

                var statement =
                    "select  id  from device";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            for (var i = 0; i < r.FieldCount; i++)
                                deviceIds.Add(r.GetInt32(i));
                    }
                }
            }

            return deviceIds;
        }

        public ObservableCollection<ILogEntry> GetAllLogEntries()
        {
            var logEntries = new ObservableCollection<ILogEntry>();
            using (var conn = MySqlConnection)
            {
                conn.Open();

                var statement =
                    "select id, pod, location, hostname, severity, timestamp, message from v_logentries order by timestamp";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ILogEntry logEntry = new LogEntry(r.GetString(3), r.GetString(6), r.GetInt32(4));
                            logEntry.Id = r.GetInt32(0);
                            logEntry.Pod = r.GetString(1);
                            logEntry.Location = r.GetString(2);
                            logEntry.Timestamp = r.GetDateTime(5);
                            logEntries.Add(logEntry);
                        }
                    }
                }
            }

            return logEntries;
        }

        public ObservableCollection<string> GetAllHostname()
        {
            var hostnames = new ObservableCollection<string>();
            using (var conn = MySqlConnection)
            {
                conn.Open();

                var statement =
                    "select  hostname  from device";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            for (var i = 0; i < r.FieldCount; i++)
                                hostnames.Add(r.GetString(i));
                    }
                }
            }

            return hostnames;
        }
    }
}