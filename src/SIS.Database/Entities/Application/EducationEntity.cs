using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkOut.Database.Entities.Application
{
    public class EducationEntity
    {
        [Key]
        public Guid ApplicationEntityId { get; set; }

        public string HighSchoolGraduationInfo { get; set; }
        public string CollegeGraduationInfo { get; set; }
        public string FieldOfStudy { get; set; }
        public bool CurrentlyEnrolled { get; set; }
    }
}
