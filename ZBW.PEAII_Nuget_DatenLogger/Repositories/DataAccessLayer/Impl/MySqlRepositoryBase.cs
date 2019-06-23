using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using DuplicateCheckerLib;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl
{
    public abstract class MySqlRepositoryBase<M> : IRepositoryBase<M>
    {
        private MySqlConnection _mySqlConnection;

        public void SetConnectionString(string connString)
        {
            Settings.Default.Connectionstring = connString;
        }
        private string GetConnectionString()
        {
            return Settings.Default.Connectionstring;
        }
        protected abstract M CreateEntity(IDataReader r);
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
            /*
                       using (var conn = MySqlConnection)
                       {
                           conn.Open();
                           var procedureName = "logMessageAdd";
                           using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
                           {
                               var p1 = new MySqlParameter("i_pod", entity.DeviceId); //char(36)
                               p1.Direction = ParameterDirection.Input;
                               p1.DbType = DbType.String;
                               var p2 = new MySqlParameter("i_hostname", entity.Hostname); //varchar(50)
                               p2.Direction = ParameterDirection.Input;
                               p2.DbType = DbType.String;
                               var p3 = new MySqlParameter("i_severity", entity.Severity); //char(36)
                               p3.Direction = ParameterDirection.Input;
                               p3.DbType = DbType.Int32;
                               var p4 = new MySqlParameter("i_message", entity.Message); //varchar(2000)
                               p4.Direction = ParameterDirection.Input;
                               p4.DbType = DbType.String;
                               var p5 = new MySqlParameter("i_location", entity.Location); //varchar(2000)
                               p5.Direction = ParameterDirection.Input;
                               p5.DbType = DbType.String;
           
                               cmd.Parameters.Add(p1);
                               cmd.Parameters.Add(p2);
                               cmd.Parameters.Add(p3);
                               cmd.Parameters.Add(p4);
                               cmd.Parameters.Add(p5);
                               cmd.ExecuteNonQuery();
                           }
                       }*/
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
                using (var cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName ))
                {
                    for (int i = 0; i < mySqlParameters.Count; i++)
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

        protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string coomandText)
        {
            var command = MySqlConnection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = coomandText;

            return command;
        }
        //protected MySqlRepositoryBase()
        //{
        //    MySqlConnection = new MySqlConnection(Settings.Default.Connectionstring);
        //}

        //protected MySqlRepositoryBase(string connString)
        //{
        //    MySqlConnection = new MySqlConnection(connString);
        //}

        //protected IDbConnection MySqlConnection { get; set; }

        ////protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string coomandText)
        ////{
        ////    var command = MySqlConnection.CreateCommand();
        ////    command.CommandType = commandType;
        ////    command.CommandText = coomandText;

        ////    return command;
        ////}

        //protected void DeleteRow(string tablename, string rowName, int value)
        //{
        //    var statement = "DELETE FROM " + tablename + " WHERE " + rowName + " = " + value + ";";
        //    ExecuteStatement(statement);
        //}

        //protected void UpdateRow(string tablename, string rowName, object newValue, int id, string idName)
        //{
        //    var statement = "UPDATE " + tablename + " SET " + rowName + " = " + newValue + " WHERE " + idName + " = " + id +
        //                    ";";
        //    ExecuteStatement(statement);
        //}

        //private void ExecuteStatement(string statement)
        //{
        //    try
        //    {
        //        MySqlConnection.Open();
        //        var command = CreateCommand(MySqlConnection, CommandType.Text, statement);
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        MessageBox.Show(e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        MySqlConnection.Close();
        //    }
        //}

    }
}