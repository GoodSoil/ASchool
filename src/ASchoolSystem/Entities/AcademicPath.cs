// DOCUMENT: XML Doc Comments for class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASchoolSystem.Entities
{
    /// <summary>
    /// Name and Description
    /// </summary>
    public class AcademicPath
    {
        public int AcademicPathID { get; set; }
        public string PathName { get; set; }
        public string Description { get; set; }
        public int RequiredCredits { get; set; }
        public bool Designation { get; set; }
    }
}
