using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl
{
    public abstract class MySqlRepositoryBase<M> : IRepositoryBase<M>
    {
        private MySqlConnection _mySqlConnection;

        protected IDbConnection MySqlConnection
        {
            get
            {
                if (_mySqlConnection == null) _mySqlConnection = new MySqlConnection(GetConnectionString());
                return _mySqlConnection;
            }
        }

        public void Add(M entity)
        {
            throw new NotImplementedException();
        }

        public long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public abstract string TableName { get; }

        public long Count()
        {
            using (var conn = MySqlConnection)
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = $"select count(*) from {TableName}";

                    return (long) cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(M entity)
        {
            throw new NotImplementedException();
        }

        public void ExecuteStoreProcedur(string procedureName, List<MySqlParameter> mySqlParameters, List<DbType> dbTypes)
        {
            using (var conn = MySqlConnection)
            {
                conn.Open();
                using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
                {
                    for (var i = 0; i < mySqlParameters.Count; i++)
                    {
                        var p = mySqlParameters[i];
                        p.Direction = ParameterDirection.Input;
                        p.DbType = dbTypes[i];
                        cmd.Parameters.Add(p);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            var allEntries = new List<M>();
            using (var conn = MySqlConnection)
            {
                conn.Open();

                var statement = $"select * from{TableName} where {whereCondition}";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var entity = CreateEntity(r);
                            allEntries.Add(entity);
                        }
                    }
                }
            }

            return allEntries;
        }

        public List<M> GetAll()
        {
            var allEntries = new List<M>();
            using (var conn = MySqlConnection)
            {
                conn.Open();

                var statement = $"select * from {TableName}";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var entity = CreateEntity(r);
                            allEntries.Add(entity);
                        }
                    }
                }
            }

            return allEntries;
        }

        public M GetSingle<P>(P pkValue)
        {
            using (var conn = MySqlConnection)
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                var statement = $"select * from {TableName} where id = {pkValue}";
                using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var entity = CreateEntity(r);

                            return entity;
                        }
                    }
                }
            }

            throw new EntryPointNotFoundException();
        }


        public void Update(M entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<M> Query(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public void SetConnectionString(string connString)
        {
            Settings.Default.Connectionstring = connString;
        }

        private string GetConnectionString()
        {
            return Settings.Default.Connectionstring;
        }

        protected abstract M CreateEntity(IDataReader r);

        protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string commandText)
        {
            var command = MySqlConnection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;

            return command;
        }
    }
}