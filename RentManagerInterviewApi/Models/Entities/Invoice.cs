using RentManagerInterviewApi.Models.Common;

namespace RentManagerInterviewApi.Models.Entities
{
    public class Invoice: BaseEntity
    {
        public int LeaseId { get; set; }
        public LeaseAgreement LeaseAgreement { get; set; } = new();
        public int AmountDue { get; set; }
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;
        public ICollection<Payment> Payments { get; set; } = [];

    }
}
