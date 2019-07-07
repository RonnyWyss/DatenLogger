using System;
using System.Linq;
using System.Linq.Expressions;
using LinqToDB;
using LinqToDB.Data;
using ZBW.PEAII_Nuget_DatenLogger.Properties;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl
{
    public abstract class MySqlRepositoryBase<TDto, TId> : DataConnection, IMySqlRepositoryBase<TDto> where TDto : BaseDTO<TId>
    {
        protected const string DatabaseName = "inventarisierungsloesung";

        public MySqlRepositoryBase() : base(DatabaseName)
        {
        }

        public void Add(TDto entity)
        {
            using (var ctx = new DataContext(DatabaseName))
            {
                ctx.Insert(entity);
            }
        }

        public long Count()
        {
            var count = GetAll().ToList().Count;

            return count;
        }

        public void Delete(TDto entity)
        {
            using (var ctx = new DataContext(DatabaseName))
            {
                var toDeleteEntry = GetAll(d => d.Id.Equals(entity.Id)).FirstOrDefault();
                if (toDeleteEntry != null) ctx.Delete(toDeleteEntry);
            }
        }

        public void ExecuteStoreProcedur(string procedureName, DataParameter[] dataParameters)
        {
            using (var db = new DataConnection(DatabaseName))
            {
                db.QueryProc<TDto>(procedureName, dataParameters);
            }
        }

        public IQueryable<TDto> GetAll(Expression<Func<TDto, bool>> parameterValues)
        {
            var allEntries = Enumerable.Empty<TDto>().AsQueryable();
            using (var db = new DataContext(DatabaseName))
            {
                allEntries = db.GetTable<TDto>().Where(parameterValues);
            }

            return allEntries;
        }


        public IQueryable<TDto> GetAll()
        {
            using (var ctx = new DataContext(DatabaseName))
            {
                var allEntries = ctx.GetTable<TDto>();
                return allEntries;
            }
        }


        public TDto GetSingle<P>(P pkValue)
        {
            using (var ctx = new DataContext(DatabaseName))
            {
                var entry = ctx.GetTable<TDto>().FirstOrDefault(e => e.Id.Equals(pkValue));

                return entry;
            }
        }


        public void Update(TDto entity)
        {
            using (var ctx = new DataContext(DatabaseName))
            {
                ctx.Update(entity);
            }
        }

        public IQueryable<TDto> Query(Expression<Func<TDto, bool>> whereClause)
        {
            using (var db = new DataContext(DatabaseName))
            {
                var entities = db.GetTable<TDto>().Where(whereClause);

                return entities;
            }
        }

        public long Count(Expression<Func<TDto, bool>> whereCondition)
        {
            using (var db = new DataContext(DatabaseName))
            {
                var entities = db.GetTable<TDto>().Where(whereCondition);

                return entities.Count();
            }
        }

        public void SetConnectionString(string connString)
        {
            Settings.Default.Connectionstring = connString;
        }

        private string GetConnectionString()
        {
            return Settings.Default.Connectionstring;
        }

       }
}