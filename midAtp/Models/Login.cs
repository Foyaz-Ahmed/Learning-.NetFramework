using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}