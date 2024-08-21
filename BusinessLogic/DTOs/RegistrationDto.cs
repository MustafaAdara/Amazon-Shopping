using System.ComponentModel.DataAnnotations;

namespace Amazon.DTOs
{
    public class RegistrationDto
    {
        [Required]
        public string UserName  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image {  get; set; }
    }
}
