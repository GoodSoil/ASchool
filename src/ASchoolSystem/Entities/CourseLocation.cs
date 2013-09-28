// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASchoolSystem.Entities
{
    //[TableName("ASchool_CourseLocation")]
    //[PrimaryKey("CourseLocationID")]
    /// <summary>
    /// A CourseLocation is for a specific CourseOffering and has a room and a time slot (start/end)
    /// </summary>
    public class CourseLocation
    {
        public int CourseLocationID { get; set; }
        public int CourseOfferingID { get; set; }
        public string RoomNumber { get; set; }
        public DateTime FirstClass { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
