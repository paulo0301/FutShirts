using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public class UserLogin
    {   
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email necessário")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Senha necessário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}