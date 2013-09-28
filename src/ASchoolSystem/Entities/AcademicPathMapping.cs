// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASchoolSystem.Entities
{
    /// <summary>
    /// An association between a course and a career path
    /// </summary>
    public class AcademicPathMapping
    {
        public int AcademicPathMappingID { get; set; }
        public int AcademicPathID { get; set; }
        public int CourseID { get; set; }
        public int? MappingDesignationID { get; set; }

        //[IgnoreColumn]
        public MappingDesignation Mapping { get; set; }
        //[IgnoreColumn]
        public AcademicPath AcademicPath { get; set; }
    }
}
