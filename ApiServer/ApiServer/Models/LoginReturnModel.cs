using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class LoginReturnModel: BaseModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string HandShake { get; set; }
    }
}