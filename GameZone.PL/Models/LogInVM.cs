using System.ComponentModel.DataAnnotations;

namespace GameZone.PL.Models
{
    public class LogInVM
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
