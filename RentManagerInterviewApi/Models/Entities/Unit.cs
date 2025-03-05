using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentManagerInterviewApi.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RentManagerInterviewApi.Models.Entities
{
    public class Unit : BaseEntity
    {

        public string UnitNumber { get; set; } = string.Empty;
        // Make Status read-write
        public UnitStatus Status { get; set; } = UnitStatus.Available;

        [ForeignKey(nameof(Apartment))]
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        // Navigation property for Tenant
        public Tenant? Tenant { get; set; }

    }
}
   
