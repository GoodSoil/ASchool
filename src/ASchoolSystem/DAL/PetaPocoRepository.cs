using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL.PetaPoco;
using ASchoolSystem.Entities;

namespace ASchoolSystem.DAL
{
    public class PetaPocoRepository<T> : IRepository<T>, IDisposable
        where T : class
    {
        private readonly Database _database;
        private readonly IMapper _mapper;

        #region Constructors

        public PetaPocoRepository(Database database, IMapper mapper)
        {
            if (database == null)
                throw new ArgumentNullException("database", "database is null.");

            _database = database;
            _mapper = mapper;
        }

        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            if (_database != null)
                _database.Dispose();
        }
        #endregion

        /// <summary>
        /// Delete an Item from the repository
        /// </summary>
        /// <param name="item">The item to be deleted</param>
        /// <returns></returns>
        public int Delete(T item) // DOCUMENT: Returns in XML comments
        {
            return _database.Delete(item);
        }
        /// <summary>
        /// Delete items from the repository based on a sql Condition
        /// </summary>
        /// <param name="sqlCondition">The sql condition e.g. "WHERE ArticleId = {0}"</param>
        /// <param name="args">A collection of arguments to be mapped to the tokens in the sqlCondition</param>
        /// <returns></returns>
        public int Delete(string sqlCondition, params object[] args) // DOCUMENT: Returns in XML comments
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find items from the repository based on a sql condition
        /// </summary>
        /// <remarks>Find supports both full SQL statements such as "SELECT * FROM table WHERE ..." 
        /// as well as a SQL condition like "WHERE ..."</remarks>
        /// <param name="sqlCondition">The sql condition e.g. "WHERE ArticleId = {0}"</param>
        /// <param name="args">A collection of arguments to be mapped to the tokens in the sqlCondition</param>
        /// <returns>A list of items</returns>
        public IEnumerable<T> Find(string sqlCondition, params object[] args)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find a GetPage of items from the repository based on a sql condition
        /// </summary>
        /// <remarks>Find supports both full SQL statements such as "SELECT * FROM table WHERE ..." 
        /// as well as a SQL condition like "WHERE ..."</remarks>
        /// <param name="pageIndex">The page Index to fetch</param>
        /// <param name="pageSize">The size of the page to fetch</param>
        /// <param name="sqlCondition">The sql condition e.g. "WHERE ArticleId = {0}"</param>
        /// <param name="args">A collection of arguments to be mapped to the tokens in the sqlCondition</param>
        /// <returns>A list of items</returns>
        public IPagedList<T> Find(int pageIndex, int pageSize, string sqlCondition, params object[] args)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns all the items in the repository as an enumerable list
        /// </summary>
        /// <returns>The list of items</returns>
        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns an enumerable list of items filtered by scope
        /// </summary>
        /// <remarks>
        /// This overload should be used to get a list of items for a specific module 
        /// instance or for a specific portal dependening on how the items in the repository 
        /// are scoped.
        /// </remarks>
        /// <typeparam name="TScopeType">The type of the scope field</typeparam>
        /// <param name="scopeValue">The value of the scope to filter by</param>
        /// <returns>The list of items</returns>
        public IEnumerable<T> Get<TScopeType>(TScopeType scopeValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get an individual item based on the items Id field
        /// </summary>
        /// <typeparam name="TProperty">The type of the Id field</typeparam>
        /// <param name="id">The value of the Id field</param>
        /// <returns>An item</returns>
        public T GetById<TProperty>(TProperty id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get an individual item based on the items Id field
        /// </summary>
        /// <remarks>
        /// This overload should be used to get an item for a specific module
        /// instance or for a specific portal dependening on how the items in the repository 
        /// are scoped. This will allow the relevant cache to be searched first.
        /// </remarks>
        /// <typeparam name="TProperty">The type of the Id field</typeparam>
        /// <param name="id">The value of the Id field</param>
        /// <typeparam name="TScopeType">The type of the scope field</typeparam>
        /// <param name="scopeValue">The value of the scope to filter by</param>
        /// <returns>An item</returns>
        public T GetById<TProperty, TScopeType>(TProperty id, TScopeType scopeValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a page of items in the repository as a paged list
        /// </summary>
        /// <param name="pageIndex">The page Index to fetch</param>
        /// <param name="pageSize">The size of the page to fetch</param>
        /// <returns>The list of items</returns>
        public IPagedList<T> GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a page of items in the repository as a paged list filtered by scope
        /// </summary>
        /// <remarks>
        /// This overload should be used to get a list of items for a specific module 
        /// instance or for a specific portal dependening on how the items in the repository 
        /// are scoped.
        /// </remarks>
        /// <typeparam name="TScopeType">The type of the scope field</typeparam>
        /// <param name="scopeValue">The value of the scope to filter by</param>
        /// <param name="pageIndex">The page Index to fetch</param>
        /// <param name="pageSize">The size of the page to fetch</param>
        /// <returns>The list of items</returns>
        public IPagedList<T> GetPage<TScopeType>(TScopeType scopeValue, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Inserts an Item into the repository
        /// </summary>
        /// <param name="item">The item to be inserted</param>
        /// <returns>The item that was inserted, with any modified values (such as Primary Keys)</returns>
        public object Insert(T item)
        {
            return _database.Insert(item);
        }
        /// <summary>
        /// Updates an Item in the repository
        /// </summary>
        /// <param name="item">The item to be updated</param>
        /// <returns></returns>
        public int Update(T item) // DOCUMENT: Returns in XML comments
        {
            return _database.Update(item);
        }
        /// <summary>
        /// Update items in the repository based on a sql Condition
        /// </summary>
        /// <param name="sqlCondition">The sql condition e.g. "SET ArticelName = {0} WHERE ArticleId = {0}"</param>
        /// <param name="args">A collection of arguments to be mapped to the tokens in the sqlCondition</param>
        /// <returns></returns>
        public int Update(string sqlCondition, params object[] args) // DOCUMENT: Returns in XML comments
        {
            throw new NotImplementedException();
        }
    }
}
