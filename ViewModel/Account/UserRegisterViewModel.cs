using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ViewModel
{
    public class UserRegisterViewModel
    {
        [Required , StringLength(50,MinimumLength =3 ), Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, StringLength(50, MinimumLength = 3), EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(50, MinimumLength = 3), Display(Name = "Full Name")]

        public string FullName { get; set; }
        [Required, StringLength(50, MinimumLength = 3), Column(TypeName = "Password"), Compare("PasswordConfirm")]

        public string Password { get; set; }
        [Required, StringLength(50, MinimumLength = 3), Column(TypeName = "Password"), Display(Name ="Confirm Password")]

        public string PasswordConfirm { get; set; }


        //public string Role { get; set; }
    }
}
