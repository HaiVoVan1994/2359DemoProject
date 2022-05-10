using InterviewProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewProject.Domains
{
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
