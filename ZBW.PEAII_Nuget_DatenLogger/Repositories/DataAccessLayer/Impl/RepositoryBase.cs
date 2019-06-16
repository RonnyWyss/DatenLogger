﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Persistence
{
    internal class RepositoryBase<M> : IRepositoryBase<M>
    {
        protected RepositoryBase()
        {
            MySqlConnection = new MySqlConnection(Settings.Default.Connectionstring);
        }

        protected RepositoryBase(string connString)
        {
            MySqlConnection = new MySqlConnection(connString);
        }

        protected IDbConnection MySqlConnection { get; set; }


        /*
         *
         *
         *
         *
         *
         */


        public M GetSingle<P>(P pkValue)
        {
            throw new NotImplementedException();
        }

        public void Add(M entity)
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

        public List<M> GetAll()
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

        public string TableName { get; }

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