using System.ComponentModel.DataAnnotations;

namespace RentManagerInterviewApi.Models.Dtos.Tenant
{
    public class TenantDisplayDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string ApartmentName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;
    }
}
