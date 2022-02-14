using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Exceptions
{
    public class UsernameDuplicateException : Exception
    {
        string msg;
        public UsernameDuplicateException()
        {
            msg = "Username already present";
        }
        public override string Message => msg;
    }
}
