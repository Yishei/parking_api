using System.ComponentModel.DataAnnotations;

namespace parking_api.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; } = null!;

        [Phone]
        [Required]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 digits.")]
        public string PhoneNumber { get; set; }

        [Phone]
        [StringLength(20, ErrorMessage = "Secondary phone number cannot be longer than 20 digits.")]
        public string? PhoneSecondary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Created By User Id must be greater than 0.")]
        public int? CreatedByUserId { get; set; }

        public string UserRole { get; set; } = "resident";
    }
}