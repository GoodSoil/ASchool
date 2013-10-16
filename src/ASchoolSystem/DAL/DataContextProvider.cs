using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL.PetaPoco;
using System.Data.Common;

namespace ASchoolSystem.DAL
{
    internal class DataContextProvider : IDataContextProvider
    {
        #region Public Methods

        public IDataContext Instance()
        {
            var defaultConnectionStringName = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["connectionStringName"]].ConnectionString;

            return new PetaPocoDataContext(defaultConnectionStringName);
        }

        public IDataContext Instance(string connectionStringName)
        {
            return new PetaPocoDataContext(connectionStringName);
        }

        #endregion
    }

    public class PetaPocoDataContext : Database, IDataContext
    {
        /// <summary>
        /// Construct a database using a supplied IDbConnection
        /// </summary>
        /// <param name="connection">The IDbConnection to use</param>
        /// <remarks>
        /// The supplied IDbConnection will not be closed/disposed by PetaPoco - that remains
        /// the responsibility of the caller.
        /// </remarks>
        public PetaPocoDataContext(IDbConnection connection)
            : base(connection)
        {
            
        }

        /// <summary>
        /// Construct a database using a supplied connections string and optionally a provider name
        /// </summary>
        /// <param name="connectionString">The DB connection string</param>
        /// <param name="providerName">The name of the DB provider to use</param>
        /// <remarks>
        /// PetaPoco will automatically close and dispose any connections it creates.
        /// </remarks>
        public PetaPocoDataContext(string connectionString, string providerName)
            : base(connectionString, providerName)
        {
            
        }

        /// <summary>
        /// Construct a PetaPocoDataContext using a supplied connection string and a DbProviderFactory
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="provider">The DbProviderFactory to use for instantiating IDbConnection's</param>
        public PetaPocoDataContext(string connectionString, DbProviderFactory provider)
            : base(connectionString, provider)
        {
            
        }

        /// <summary>
        /// Construct a PetaPocoDataContext using a supplied connectionString Name.  The actual connection string and provider will be 
        /// read from app/web.config.
        /// </summary>
        /// <param name="connectionStringName">The name of the connection</param>
        public PetaPocoDataContext(string connectionStringName)
            : base(connectionStringName)
        {
            
        }


        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Execute(CommandType type, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteQuery<T>(CommandType type, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public T ExecuteScalar<T>(CommandType type, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public T ExecuteSingleOrDefault<T>(CommandType type, string sql, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new PetaPocoRepository<T>(this,Mappers.GetMapper(typeof(T)));
        }

        public void RollbackTransaction()
        {
            base.AbortTransaction();
        }
    }
}
