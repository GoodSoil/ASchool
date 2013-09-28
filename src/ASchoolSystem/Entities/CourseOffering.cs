// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASchoolSystem.Entities
{
    //[TableName("ASchool_CourseOffering")]
    //[PrimaryKey("CourseOfferingID")]
    /// <summary>
    /// A CourseOffering is for a specific course in a specific Academic Term. It also has a section name.
    /// </summary>
    public class CourseOffering
    {
        public int CourseOfferingID { get; set; }
        public int CourseID { get; set; }
        public int AcademicTermID { get; set; }
        public string SectionName { get; set; }

        //[IgnoreColumn]
        public Course Course { get; set; }
        public List<CourseLocation> Locations { get; set; }
        public AcademicTerm Term { get; set; }
    }
}
