using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiServer.Exceptions
{
    public static class ExceptionDefines
    {
        public class UserNotFoundEx:Exception { };
        public class InternalErrorEx:Exception { };
    }
}