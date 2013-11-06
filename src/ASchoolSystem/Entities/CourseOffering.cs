// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL.PetaPoco;

namespace ASchoolSystem.Entities
{
    //[TableName("ASchool_CourseOffering")]
    //[PrimaryKey("CourseOfferingID")]
    /// <summary>
    /// A CourseOffering is for a specific course in a specific Academic Term. It also has a section name.
    /// </summary>
    [PrimaryKey("CourseOfferingID")]
    public class CourseOffering
    {
        public int CourseOfferingID { get; set; }
        public int CourseID { get; set; }
        public int AcademicTermID { get; set; }
        public string SectionName { get; set; }

        [Ignore] public Course Course { get; set; }
        [Ignore] public List<CourseLocation> Locations { get; set; }
        [Ignore] public AcademicTerm Term { get; set; }
    }
}
