using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiServer.Defines
{
    public static class ResponseCode
    {
        //2xx
        public static readonly int SUCCESS = 200;

        //4xx
        public static readonly int BAD_REQUEST = 400;
        public static readonly int NOT_FOUND = 404;


        //5xx
        public static readonly int INTERNAL_ERROR = 500;

    }
}