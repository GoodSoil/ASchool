// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL.PetaPoco;

namespace ASchoolSystem.Entities
{
    /// <summary>
    /// An association between a course and a career path
    /// </summary>
    [PrimaryKey("AcademicPathMappingID")]
    public class AcademicPathMapping
    {
        public int AcademicPathMappingID { get; set; }
        public int AcademicPathID { get; set; }
        public int CourseID { get; set; }
        public int? MappingDesignationID { get; set; }

        [Ignore]
        public MappingDesignation Mapping { get; set; }
        [Ignore]
        public AcademicPath AcademicPath { get; set; }
    }
}
