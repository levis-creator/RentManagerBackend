using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Models.Dtos.Invoice
{
    public class InvoiceDisplayDto
    {
        public int Id { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public int AmountDue { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public InvoiceStatus Status { get; set; }
    }
}
