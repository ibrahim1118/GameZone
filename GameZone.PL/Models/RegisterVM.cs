using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameZone.PL.Models
{
    public class RegisterVM
    {
    
        [MinLength(2)]
        [DisplayName("First Name")]
        public string FName { get; set; }
        [MinLength(2)]
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
