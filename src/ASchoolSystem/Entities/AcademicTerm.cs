// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASchoolSystem.Entities
{
    //[TableName("ASchool_AcademicTerm")]
    //[PrimaryKey("AcademicTermID")]
    /// <summary>
    /// Can be either a semester, trimester, or quarter. It has a start date, end date, and duration (in weeks, excluding weeks off such as Reading Break)
    /// </summary>
    public class AcademicTerm
    {
        public int AcademicTermID { get; set; }
        public string Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeeksDuration { get; set; }

        public enum TermType { Unknown, Semester, Trimester, Quarter }
    }
}
