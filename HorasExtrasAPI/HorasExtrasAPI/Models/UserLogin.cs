using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtrasAPI.Models
{
    public class UserLogin
    {
        [Required]
        public string user { get; set; }
        [Required]
        public string Pwd { get; set; }
    }
}
