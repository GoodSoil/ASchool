// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL.PetaPoco;

namespace ASchoolSystem.Entities
{
    /// <summary>
    /// A course may have certain dependencies on other courses. Depedent relationships may be "Prerequisite" or "Corequisite". The relationship may be "Required" or "Suggested".
    /// </summary>
    [PrimaryKey("CourseDependencyID")]
    public class CourseDependency
    {
        public int CourseDependencyID { get; set; }
        public int CourseID { get; set; }
        public int DependsOnCourseID { get; set; }
        public string Relationship { get; set; }
        public string Connection { get; set; }

        public enum DependencyRelationship { Unknown, Prerequisite, Corequisite }
        public enum DependencyConnection { Undetermined, Required, Suggested }
    }
}
