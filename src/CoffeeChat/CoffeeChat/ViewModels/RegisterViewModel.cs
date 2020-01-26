using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeChat.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
