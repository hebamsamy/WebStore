using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ViewModel
{
    public class UserLoginViewModel
    {
        [Required, StringLength(50, MinimumLength = 3), EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(50, MinimumLength = 3), Column(TypeName = "Password")]

        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
