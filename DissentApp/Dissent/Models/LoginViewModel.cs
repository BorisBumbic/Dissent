using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissent.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[A-Z])(?=.*\d)(?=.*[a-z])|(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%&\/=?_.-])|(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%&\/=?_.-])|(?=.*\d)(?=.*[a-z])(?=.*[!@#$%&\/=?_.-])).{7,15}$",
         ErrorMessage = "Passowrd must contain atleast 4 character and no more than 8 character long"+
                        "must contain uppercase letter"+
                        "must contain a number and sysmbol")]
        public string Password { get; set; }
    }
}
