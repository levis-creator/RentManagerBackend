using RentManagerInterviewApi.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Entities
{
    public class Payment:BaseEntity
    {
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = new();
        public int AmountPaid { get; set; }
        public DateOnly PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;

    }
}
