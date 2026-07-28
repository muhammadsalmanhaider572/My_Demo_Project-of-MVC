using System.ComponentModel.DataAnnotations;

namespace My_Demo_Project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression("^(?=.{3,50}$)(?=.*[A-Za-z]).+$", ErrorMessage = "Name must be 3-50 characters and include at least one letter.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^\\d{11}$", ErrorMessage = "Phone must be exactly 11 digits.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9_]{3,19}$", ErrorMessage = "Username must start with a letter and be 4-20 characters (letters, numbers, underscore).")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*\\W).{8,}$", ErrorMessage = "Password must be at least 8 characters and include an uppercase letter, a digit and a special character.")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
