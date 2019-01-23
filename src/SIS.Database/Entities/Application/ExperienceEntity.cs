using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkOut.Database.Entities.Application
{
    public class ExperienceEntity
    {
        [Key]
        public Guid ApplicationEntityId { get; set; }

        public string EmploymentStatus { get; set; }
        public string IncomeLevel { get; set; }
    }
}
