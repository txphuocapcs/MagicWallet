using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class UniversalResposeModel
    {
        [Required]
        public int code { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public BaseModel result { get; set; }

        public void SetCode(int _code)
        {
            code = _code;
        }
        public void SetMessage(string _message)
        {
            message = _message;
        }
        public void SetResult(BaseModel _result)
        {
            result = _result;
        }
    }
}