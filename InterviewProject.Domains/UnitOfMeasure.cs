using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domains
{
    [Table("UnitOfMeasure")]
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
    }
}
