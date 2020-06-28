using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "email is required")]
        [EmailAddress]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        // [Required(ErrorMessage = "password is required")]
        // [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
        // ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        public string Password { get; set; }
    }
}