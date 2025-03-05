using RentManagerInterviewApi.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Entities
{
    public class Apartment : BaseEntity
    {
        public string ApartmentName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [ForeignKey(nameof(PropertyOwner))]
        public int OwnerId { get; set; }
        public virtual PropertyOwner? PropertyOwner { get; set; }

        public virtual ICollection<Unit> Units { get; set; } = [];
    }
}
