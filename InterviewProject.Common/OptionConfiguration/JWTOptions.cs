using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Common.OptionConfiguration
{
    public class JWTOptions
    {
        public const string JWTOption = "JWTOptions";
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
    }
}
