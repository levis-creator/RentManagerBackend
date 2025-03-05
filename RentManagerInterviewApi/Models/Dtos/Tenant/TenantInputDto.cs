using System.ComponentModel.DataAnnotations;

namespace RentManagerInterviewApi.Models.Dtos.Tenant
{
    public class TenantInputDto
    {
        [Required(ErrorMessage = "Full Name is required")]
        [MinLength(3, ErrorMessage = "Full Name must be at least 3 characters")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } = string.Empty;

        public int? UnitId { get; set; }
    }
}
