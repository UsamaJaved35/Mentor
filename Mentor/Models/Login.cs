using System.ComponentModel.DataAnnotations;

namespace Mentor.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter valid Email:")]
        [EmailAddress]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "Incorrect Email or Password")]
        [DataType(DataType.Password)]
        public string ?Password { get; set; }
    }
}
