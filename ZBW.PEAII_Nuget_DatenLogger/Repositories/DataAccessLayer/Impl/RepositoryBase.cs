using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase()
        {
            ConnectionString = Settings.Default.Connectionstring;
        }

        protected RepositoryBase(string connString)
        {
            ConnectionString = connString;
        }

        protected string ConnectionString { get; }

        protected IDbConnection MySqlConnection { get; set; }

       
    }
}