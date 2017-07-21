using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiServer.Models;
using ApiServer.Defines;
using ApiServer.SQL;
using ApiServer.Exceptions;

namespace ApiServer.Controllers
{
    public class LoginController : ApiController
    {
        //attributes
        SQLOperator sqlOp = SQLOperator.Instance;
    

        [Route("api/login")]
        [HttpPost]
        public UniversalResposeModel userLogin(LoginModel _UserInput)
        {
            if (ModelState.IsValid)
            {
                var ret = new UniversalResposeModel();
                try
                {
                    var userReturnModel = sqlOp.userLogin(_UserInput.UserName, _UserInput.Password);
                    ret.SetCode(ResponseCode.SUCCESS);
                    ret.SetMessage("Request completed successfully!");
                    ret.SetResult(userReturnModel);
                    return ret;
                }
                catch (ExceptionDefines.UserNotFoundEx ex)
                {
                    ret.SetCode(ResponseCode.NOT_FOUND);
                    ret.SetMessage("Wrong username or password!");
                    ret.SetResult(null);
                    return ret;
                }
                catch(ExceptionDefines.InternalErrorEx ex)
                {
                    ret.SetCode(ResponseCode.INTERNAL_ERROR);
                    ret.SetMessage("Internal server error!");
                    ret.SetResult(null);
                    Console.WriteLine(ex.ToString());
                    return ret;
                }
            }
            else
            {
                var ret = new UniversalResposeModel();
                ret.SetCode(ResponseCode.BAD_REQUEST);
                ret.SetMessage("Missing required request field(s)!");
                ret.SetResult(null);
                return ret;
            }
        }
    }
}
