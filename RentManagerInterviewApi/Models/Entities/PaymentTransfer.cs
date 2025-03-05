using RentManagerInterviewApi.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Entities
{
    public class PaymentTransfer : BaseEntity
    {
        public int? TenantId { get; set; } 
        [ForeignKey("TenantId")]
        public virtual Tenant? Tenant { get; set; }

        public int? ToUnitId { get; set; }
        [ForeignKey("ToUnitId")]
        public virtual Unit? ToUnit { get; set; }

        public DateOnly TransferDate { get; set; }
    }
}
