using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiServer.SQL;
using System.Data;
using System.Data.SqlClient;
using ApiServer.Exceptions;

namespace ApiServer.SQL
{
    public class SQLServices
    {
        //singleton init
        private static SQLServices instance = new SQLServices();
        public static SQLServices Instance
        {
            get
            {
                return instance;
            }
        }

        //attributes
        SQLClient sqlClient = SQLClient.Instance;

        //public methods
        //search based on username and pswd
        public DataTable loginSearch(string _userName, string _userPWD)
        {
            try
            {
                List<string> keys = new List<string>();
                List<string> values = new List<string>();
                keys.Add("@username");
                values.Add(_userName);
                keys.Add("@pswd");
                values.Add(_userPWD);
                return sqlClient.loginQuery("SELECT * FROM USERS WHERE UserName=@username AND UserPWD=@pswd",keys,values);

            }
            catch (ExceptionDefines.InternalErrorEx ex)
            {
                throw ex;
            }
        }
    }
}