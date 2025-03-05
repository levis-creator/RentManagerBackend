using RentManagerInterviewApi.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace RentManagerInterviewApi.Models.Entities
{
    public class PropertyOwner:BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;
        public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    }
}
