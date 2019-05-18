using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    public class MySqlRepository
    {
        protected MySqlRepository()
        {
            MySqlConnection = new MySqlConnection(Settings.Default.Connectionstring);
        }

        protected MySqlRepository(string connString)
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
    }
}