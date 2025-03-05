using RentManagerInterviewApi.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Entities
{
    public class LeaseAgreement: BaseEntity
    {
        public int? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; } 

        public DateOnly StartDate { get; set; } = new DateOnly();
        public DateOnly EndDate { get; set; } = new DateOnly();
        [Column(TypeName = "decimal(18,2)")]
        public decimal RentAmount { get; set; }
        public LeaseStatus Status { get; set; } = LeaseStatus.Active;

        public ICollection<Invoice> Invoices { get; set; } = [];

    }
}
