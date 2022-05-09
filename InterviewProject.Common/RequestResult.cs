using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Common
{
    public abstract class RequestResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Payload { get; protected set; }
    }
}
