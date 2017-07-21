using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ApiServer.SQL;
using ApiServer.Models;
using ApiServer.Exceptions;

namespace ApiServer.SQL
{
    //singleton sql operator
    public class SQLOperator
    {
        //singleton init
        private static SQLOperator instance = new SQLOperator();
        public static SQLOperator Instance
        {
            get
            {
                return instance;
            }
        }

        //attributes
        SQLServices service = SQLServices.Instance;

        //process basic user authentication
        //throw unexpected query result exception
        public LoginReturnModel userLogin(string _userName, string _userPWD)
        {
            try
            {
                DataTable queryResult = service.loginSearch(_userName, _userPWD);
                if (queryResult.Rows.Count == 1)
                {
                    LoginReturnModel returnModel = new LoginReturnModel();
                    returnModel.UserName = queryResult.Rows[0].Field<string>("UserName");
                    returnModel.HandShake = "1";
                    return returnModel;
                }
                else if (queryResult.Rows.Count == 0)
                    throw new ExceptionDefines.UserNotFoundEx();
                else
                {
                    throw new ExceptionDefines.InternalErrorEx();
                }
            }
            catch (ExceptionDefines.InternalErrorEx ex)
            {
                throw ex;
            }
        }
    }
}