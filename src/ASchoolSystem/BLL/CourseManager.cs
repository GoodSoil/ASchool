using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL;
using ASchoolSystem.Entities;

namespace ASchoolSystem.BLL
{
    /// <summary>
    /// CourseManager is responsible to retrieve, add, update, and delete Course related information in ASchoolSystem as part of the curriculum design process.
    /// </summary>
    /// <remarks>
    /// The public methods in this class follow the pattern of Command/Query Responsibility Segregation (CQRS).
    /// </remarks>
    public class CourseManager
    {
        private IDataContext DbContext { get; set; }

        public CourseManager()
            : this(new DataContextProvider(), "ASchoolDb") // TODO: Deal with literal string
        {
        }

        public CourseManager(IDataContextProvider provider, string connectionStringName)
            : this(provider.Instance(connectionStringName))
        {
        }

        public CourseManager(IDataContext dbContext)
        {
            DbContext = dbContext;
        }

        #region Command: Add, Update, Delete
        #region Public Methods
        public int AddCourse(Course data)
        {
            var repo = DbContext.GetRepository<Course>();
            return Convert.ToInt32(repo.Insert(data));
        }
        #endregion

        #region Private Methods
        #endregion
        #endregion

        // ------------------------------------------------------------------

        #region Query: Read
        #region Public Methods
        public Course GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        #endregion
        #endregion
    }
}
