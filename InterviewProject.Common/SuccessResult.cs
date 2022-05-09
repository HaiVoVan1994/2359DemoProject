using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Common
{
    public class SuccessResult<T> : RequestResult<T>
    {
        public SuccessResult(T payload)
        {
            IsSuccess = true;
            Payload = payload;
        }
    }
}
