using System.ComponentModel.DataAnnotations;

namespace DotnetTask2_WEBAPI1_Collection.Models
{
    public class Employee
    {
        
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; }
        [StringLength(maximumLength:30,MinimumLength =3,ErrorMessage ="Name must be between 3 to 30 charecters")]
        public string? Name { get; set; }
        public string? Department { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile number must be exactly 10 digits and start with a digit between 6 and 9.")]
        public string? Mobile { get; set; }

        
    }
}
