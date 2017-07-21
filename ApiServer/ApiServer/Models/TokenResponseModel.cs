using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class TokenResponseModel: BaseModel
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string accessToken { get; set; }
        [Required]
        public string expiresIn { get; set; }
    }
}