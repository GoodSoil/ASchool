// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL.PetaPoco;

namespace ASchoolSystem.Entities
{
    //[TableName("ASchool_Course")]
    //[PrimaryKey("CourseID")]
    /// <summary>
    /// A course has a designated number, name, description, and status. A course status may be either Proposed or Current. The number, name, and description of a course may be modified when the course's status is Proposed. However, when a course is made as Current, only the description may be changed, at which point the course with its previous description is also written to the ArchivedCourse table. A course may not be deleted unless it is first written to the ArchivedCourse table.
    /// </summary>
    [PrimaryKey("CourseID")]
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string Status { get; set; }

        public int ClassHourPerWeek { get; set; }
        public double Credits { get; set; }
        public int Term { get; set; }
        public string SemesterOffered { get; set; }
        public enum StatusTypes { Proposed, Current, Retired }

        [Ignore]
        public List<AcademicPathMapping> AcademicPaths { get; set; }
        [Ignore]
        public List<CourseDependency> Dependencies { get; set; }

        public Course()
        {
            AcademicPaths = new List<AcademicPathMapping>();
            Dependencies = new List<CourseDependency>();
        }
    }
            
    // TODO: ArchivedCourse
    //     - An ArchivedCourse has a designated number, name, description, and previous status, along with the archive date and reason for archiving (Canceled or Updated).


}
