using System;
using System.Data;
using System.Windows;
using DuplicateCheckerLib;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl
{
    public class MySqlRepositoryBase
    {
        protected MySqlRepositoryBase()
        {
            MySqlConnection = new MySqlConnection(Settings.Default.Connectionstring);
        }

        protected MySqlRepositoryBase(string connString)
        {
            MySqlConnection = new MySqlConnection(connString);
        }

        protected IDbConnection MySqlConnection { get; set; }

        protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string coomandText)
        {
            var command = MySqlConnection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = coomandText;

            return command;
        }

        protected void DeleteRow(string tablename, string rowName, int value)
        {
            var statement = "DELETE FROM " + tablename + " WHERE " + rowName + " = " + value + ";";
            ExecuteStatement(statement);
        }

        protected void UpdateRow(string tablename, string rowName, object newValue, int id, string idName)
        {
            var statement = "UPDATE " + tablename + " SET " + rowName + " = " + newValue + " WHERE " + idName + " = " + id +
                            ";";
            ExecuteStatement(statement);
        }

        private void ExecuteStatement(string statement)
        {
            try
            {
                MySqlConnection.Open();
                var command = CreateCommand(MySqlConnection, CommandType.Text, statement);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }

        /*
         *
         *
         **/


        public void Add(IEntity entity)
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


        /*
         *
         *
         *
         *
         *
         *
       
        public M GetSingle<P>(P pkValue)
        {
            throw new NotImplementedException();
        }



        public void Delete(M entity)
        {
            throw new NotImplementedException();
        }

        public void Update(M entity)
        {
            throw new NotImplementedException();
        }

        public List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }



        public IQueryable<M> Query(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public string TableName { get; }  */
    }
}